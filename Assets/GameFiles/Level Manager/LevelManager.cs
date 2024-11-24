using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.Linq;

namespace ButchersGames
{
    public class LevelManager : MonoBehaviour
    {
        #region Singletone
        private static LevelManager _default;
        public static LevelManager Default { get => _default; }
        public LevelManager() => _default = this;
        #endregion

        const string CurrentLevel_PrefsKey = "Current Level";
        const string CompleteLevelCount_PrefsKey = "Complete Lvl Count";
        const string LastLevelIndex_PrefsKey = "Last Level Index";
        const string CurrentAttempt_PrefsKey = "Current Attempt";

        public static int CurrentLevel { get { return (CompleteLevelCount < Default.Levels.Count ? Default.CurrentLevelIndex : CompleteLevelCount) + 1; } set { PlayerPrefs.GetInt(CurrentLevel_PrefsKey, value); } }
        public static int CompleteLevelCount { get { return PlayerPrefs.GetInt(CompleteLevelCount_PrefsKey); } set { PlayerPrefs.SetInt(CompleteLevelCount_PrefsKey, value); } }
        public static int LastLevelIndex { get { return PlayerPrefs.GetInt(LastLevelIndex_PrefsKey); } set { PlayerPrefs.SetInt(LastLevelIndex_PrefsKey, value); } }
        public static int CurrentAttempt { get { return PlayerPrefs.GetInt(CurrentAttempt_PrefsKey); } set { PlayerPrefs.SetInt(CurrentAttempt_PrefsKey, value); } }
        public int CurrentLevelIndex;

        [SerializeField] bool editorMode = false;
        [SerializeField] LevelsList levels;
        public List<Level> Levels => levels.lvls;

        public event Action OnLevelStarted;


        public void Init()
        {
#if !UNITY_EDITOR
            editorMode = false;
#endif
            if (!editorMode) SelectLevel(LastLevelIndex, true);

            if (LastLevelIndex != CurrentLevel)
            {
                CurrentAttempt = 0;
            }
        }

        private void OnDestroy()
        {
            LastLevelIndex = CurrentLevelIndex;
        }

        private void OnApplicationQuit()
        {
            LastLevelIndex = CurrentLevelIndex;
        }


        public void StartLevel()
        {
            OnLevelStarted?.Invoke();
        }

        public void RestartLevel()
        {
            SelectLevel(CurrentLevelIndex, false);
        }

        public void NextLevel()
        {
            if (!editorMode) CurrentLevel++;
            SelectLevel(CurrentLevelIndex + 1);
        }

        public void SelectLevel(int levelIndex, bool indexCheck = true)
        {
            if (indexCheck)
                levelIndex = GetCorrectedIndex(levelIndex);

            if (Levels[levelIndex] == null)
            {
                Debug.Log("<color=red>There is no prefab attached!</color>");
                return;
            }

            var level = Levels[levelIndex];

            if (level)
            {
                SelLevelParams(level);
                CurrentLevelIndex = levelIndex;
            }
        }

        public void PrevLevel() =>
            SelectLevel(CurrentLevelIndex - 1);

        private int GetCorrectedIndex(int levelIndex)
        {
            if (editorMode)
                return levelIndex > Levels.Count - 1 || levelIndex <= 0 ? 0 : levelIndex;
            else
            {
                int levelId = CurrentLevel;
                if (levelId > Levels.Count - 1)
                {
                    if (levels.randomizedLvls)
                    {
                        List<int> lvls = Enumerable.Range(0, levels.lvls.Count).ToList();
                        lvls.RemoveAt(CurrentLevelIndex);
                        return lvls[UnityEngine.Random.Range(0, lvls.Count)];
                    }
                    else return levelIndex % levels.lvls.Count;
                }
                return levelId;
            }
        }

        private void SelLevelParams(Level level)
        {
            if (level)
            {
                ClearChilds();
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                Instantiate(level, transform);
            }
            else
            {
                PrefabUtility.InstantiatePrefab(level, transform);
            }
#else
                Instantiate(level, transform);
#endif
            }
        }

        private void ClearChilds()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject destroyObject = transform.GetChild(i).gameObject;
                DestroyImmediate(destroyObject);
            }
        }
    }
}