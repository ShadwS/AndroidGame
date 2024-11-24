Shader "Mobile/Diffuse + Emission +  Specular" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,1)
		_EmissionColor ("Emission Color", Vector) = (0,0,0,1)
		[NoScaleOffset] _EmissionMap ("Emission", 2D) = "white" {}
		[PowerSlider(5.0)] _Gloss ("Gloss", Range(0, 1)) = 0.078125
		[PowerSlider(5.0)] _Shininess ("Shininess", Range(0, 1)) = 0.078125
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
	Fallback "Mobile/VertexLit"
}