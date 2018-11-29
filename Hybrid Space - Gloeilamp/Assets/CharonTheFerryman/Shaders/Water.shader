Shader "Unlit/Water"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Current("Current Speed", float) = .01
		_WaveHeight("Wave Height", Range(0.0, 1.0)) = .1
		_Color("Color", Color) = (1,1,1,1)
		[KeywordEnum(North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest)] _WindDir("Wind Direction", int) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Transparent"}
		LOD 100
		Blend One One

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
				float4 normal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			float _Current;
			float _WaveHeight;
			int _WindDir;
			
			v2f vert (appdata v)
			{
				v2f o;
				v.vertex += v.normal * sin(_Time.z * v.uv.y * v.uv.x) * _WaveHeight;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				float2 animatedUV;
				if (_WindDir == 0)animatedUV = i.uv + float2(0, _Time.z * _Current);
				if (_WindDir == 1)animatedUV = i.uv + float2(_Time.z * _Current, _Time.z * _Current);
				if (_WindDir == 2)animatedUV = i.uv + float2(_Time.z * _Current, 0);
				if (_WindDir == 3)animatedUV = i.uv + float2(-_Time.z * _Current, _Time.z * _Current);
				if (_WindDir == 4)animatedUV = i.uv + float2(0, -_Time.z * _Current);
				if (_WindDir == 5)animatedUV = i.uv + float2(-_Time.z * _Current, -_Time.z * _Current);
				if (_WindDir == 6)animatedUV = i.uv + float2(-_Time.z * _Current, 0);
				if (_WindDir == 7)animatedUV = i.uv + float2(_Time.z * _Current, -_Time.z * _Current);
				float4 col = tex2D(_MainTex, animatedUV) * _Color;
				return col;
			}
			ENDCG
		}
	}
}
