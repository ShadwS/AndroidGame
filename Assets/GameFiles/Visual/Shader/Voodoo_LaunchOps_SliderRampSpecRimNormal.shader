Shader "Voodoo_LaunchOps/SliderRampSpecRimNormal" {
	Properties {
		[TCP2HeaderHelp(BASE, Base Properties)] _Color ("Color", Vector) = (1,1,1,1)
		_HColor ("Highlight Color", Vector) = (0.785,0.785,0.785,1)
		_SColor ("Shadow Color", Vector) = (0.195,0.195,0.195,1)
		_MainTex ("Main Texture", 2D) = "white" {}
		[TCP2Separator] [TCP2Header(RAMP SETTINGS)] _RampThreshold ("Ramp Threshold", Range(0, 1)) = 0.5
		_RampSmooth ("Ramp Smoothing", Range(0.001, 1)) = 0.1
		[TCP2Separator] [TCP2HeaderHelp(NORMAL MAPPING, Normal Bump Map,)] _BumpMap ("Normal map (RGB)", 2D) = "bump" {}
		[TCP2Separator] [TCP2HeaderHelp(SPECULAR, Specular)] _SpecColor ("Specular Color", Vector) = (0.5,0.5,0.5,1)
		_Smoothness ("Size", Range(0, 1)) = 0.2
		[TCP2Separator] [TCP2HeaderHelp(RIM, RIM)] _RimColor ("Rim Color", Vector) = (0,0,0,0)
		_RimMin ("Rim Min", Range(0, 1)) = 1
		_RimMax ("Rim Max", Range(0, 5)) = 1
		[TCP2Separator] [HideInInspector] __dummy__ ("unused", Float) = 0
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
	//CustomEditor "TCP2_MaterialInspector_SG"
}