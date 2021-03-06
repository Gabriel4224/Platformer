﻿Shader "Custom/Transparent"
{
	Properties
	{
		_MainTex("Albedo Texture", 2D) = "white" {}
		_Tint("Tint Colour", Color) = (1,1,1,1)
		_Transparency("Transparency", Range(0.0,1)) = 0.25
		_CutoutThreshold("Cutout Threshold", Range(0.0,1.0)) = 0.6

  
 
	}

		SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		// ZWrite creates a semiTransprent effect when off
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
	{
		CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        
        #include "UnityCG.cginc"

		struct appdata
	{
		float4 vertex : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float2 uv : TEXCOORD0;
		float4 vertex : SV_POSITION;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;
	float4 _Tint;
	float _Transparency;
	// How much can the map see
	float _CutoutThreshold;
 
  
	// creates vertex Lighting making the shader visable
	v2f vert(appdata v)
	{
		v2f o;
 
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.uv, _MainTex);
		return o;
	}
	// Adds colour Tint to the shader
	fixed4 frag(v2f i) : SV_Target
	{
		fixed4 col = tex2D(_MainTex, i.uv) + _Tint;
	//_ColourChange += _Time.y;
 
	    col.a = _Transparency;
	    //clip(col.r - _CutoutThreshold);
	    return col;
	}
		ENDCG
	}
	}
}
