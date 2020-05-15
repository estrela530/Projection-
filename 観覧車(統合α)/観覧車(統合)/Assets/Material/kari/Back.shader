Shader "Unlit/Back"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1)
		_Light("LightScale",Range(0,5)) = 1
		_Ambient("Ambient",Color) = (1,1,1)
		_AmbientPower("AmbientPower",Range(0,5)) = 1
		_Shininess("_Shininess",float) = 0
		_SpecColor("SpecColor",Color) = (1,1,1)
	}
		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			float4 _Color;
			float _Light;
			float4 _Ambient;
			float _AmbientPower;
			float _Shininess;

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
				//面の法線と入射光の向きの内積を求める
				//光源情報は 「_WorldSpaceLightPos0」から取得できる
				float intensity = dot(i.normal, _WorldSpaceLightPos0);

				float r = saturate(_Color.r * (intensity + _Ambient.r * _AmbientPower) * _Light * pow(max(0, dot(i.normal, i.halfDir)), _Shininess));
				float g = saturate(_Color.g * (intensity + _Ambient.g * _AmbientPower) * _Light * pow(max(0, dot(i.normal, i.halfDir)), _Shininess));
				float b = saturate(_Color.b * (intensity + _Ambient.b * _AmbientPower) * _Light * pow(max(0, dot(i.normal, i.halfDir)), _Shininess));
				//内積の値だけ明るくする
				return float4(r, g, b, 1);
			}
			ENDCG
		}

		Pass
 {
	 Tags{ "LightMode" = "ShadowCaster" }

	 CGPROGRAM
	 #pragma vertex vert
	 #pragma fragment frag
	 #pragma multi_compile_shadowcaster

	 #include "UnityCG.cginc"

	 struct appdata
	 {
		 float4 vertex : POSITION;
		 float3 normal : NORMAL;
		 float2 texcoord : TEXCOORD0;
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

	 fixed4 frag(v2f i) : SV_Target
	 {
		 SHADOW_CASTER_FRAGMENT(i)
	 }
	 ENDCG
 }
	}
}

