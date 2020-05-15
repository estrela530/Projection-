Shader "Unlit/Soul"
{
		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			struct appdata//頂点情報
			{//型　変数名 : セマンティクス(何の情報か)
				float4 vertex : POSITION;
				float3 normal : NORMAL;//法線情報
			};

			struct v2f//vertex to flagment
			{
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				half3 halfDir : TEXCOORD2;
			};
			fixed4 _LightColor0;
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
				// ハーフベクトルを求める
				half3 eyeDir = normalize(_WorldSpaceCameraPos.xyz - worldPos.xyz);
				o.halfDir = normalize(_WorldSpaceLightPos0.xyz + eyeDir);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return float4(1, 1, 1, 1);
			}
			ENDCG
		}
	}
}