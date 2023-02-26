Shader "Custom/ToonShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_OutlineColor("OutlineColor", Color) = (0, 0, 0, 1)
		_OutlineSize("OutlineSize", Range(1, 5)) = 1
		[Toggle] _ShowOutline("Show Outline?", Float) = 1

		_MainTex("Albedo (RGB)", 2D) = "white" {}
		[Toggle] _ShowTexture("Show Texture?", Float) = 1
		_RampTex("Ramp Texture", 2D) = "white"{}

		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.5, 15.0)) = 15.0
		[Toggle] _ShowRimLight("Show Rim Light?", Float) = 1
	}

		SubShader
		{
			// Shadow Passes
			Pass
			{
				Tags {"LightMode" = "ForwardBase"}
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight

				#include "UnityCG.cginc" 
				#include "UnityLightingCommon.cginc"
				#include "Lighting.cginc" 
				#include "AutoLight.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					fixed4 diff : COLOR0;
					float4 pos: SV_POSITION;
					SHADOW_COORDS(1)
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.uv = v.texcoord;

					half3 worldNormal = UnityObjectToWorldNormal(v.normal);
					half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));

					o.diff = nl * _LightColor0;
					TRANSFER_SHADOW(o)
					return o;
				}

				sampler2D _MainTex;
				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 col = tex2D(_MainTex, i.uv);
					fixed shadow = SHADOW_ATTENUATION(i);
					col.rgb *= i.diff * shadow;
					return col;
				}

				ENDCG
			}

			Pass
			{
				Tags {"LightMode" = "ShadowCaster"}
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_shadowcaster

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
				};

				struct v2f
				{
					V2F_SHADOW_CASTER;
				};

				v2f vert(appdata v)
				{
					v2f o;
					TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
					return o;
				}

				float4 frag(v2f i) : SV_Target
				{
					SHADOW_CASTER_FRAGMENT(i)
				}

				ENDCG
			}

			Tags
			{
				"Queue" = "Transparent"
			}
			LOD 200

			// Outline Pass
			Pass
			{
				Stencil
				{
				Ref 1
				Comp Always
				}

				Cull Off
				ZWrite Off

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "UnityCG.cginc"

				float _OutlineSize;
				float4 _OutlineColor;
				float _ShowOutline;

				struct appdata
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
				};

				struct v2f
				{
					float4 pos : POSITION;
					float4 color : COLOR;
					float3 normal : NORMAL;
				};

				v2f vert(appdata v)
				{
					v.vertex.xyz *= (_OutlineSize)*_ShowOutline;
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					o.color = _OutlineColor;
					return o;
				}

				half4 frag(v2f i) : COLOR
				{
					return _OutlineColor;
				}

				ENDCG
			}

			// Toon Lighting

			Tags {"RenderType" = "Opaque"}
			LOD 200

			Stencil
			{
				Ref 1
				Comp Always
				Pass Replace
			}

			CGPROGRAM
			#pragma surface surf ToonRamp
			#pragma target 3.0

			float4 _Color;
			sampler2D _RampTex;
			sampler2D _MainTex;
			float _ShowTexture;
			float4 _RimColor;
			float _RimPower;
			float _ShowRimLight;

			float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten)
			{
				float diff = (dot(s.Normal, lightDir) * 0.5 + 0.5) * atten;
				float2 rh = diff;
				float3 ramp = tex2D(_RampTex, rh).rgb;

				float4 c;
				c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
				c.a = s.Alpha;
				return c;
			}

			struct Input
			{
				float2 uv_MainTex;
				float3 viewDir;
				float3 worldPos;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
				fixed4 c = (tex2D(_MainTex, IN.uv_MainTex)) * _ShowTexture;
				o.Albedo = c.rgb * _Color;
				half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
				o.Emission = (_RimColor.rgb * pow(rim, _RimPower)) * _ShowRimLight;
				o.Alpha = c.a;
			}

			ENDCG
		}

		FallBack "Diffuse"
}
