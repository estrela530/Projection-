Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_Color("Color",Color) = (0.5,1,0.2,1)
	}
		SubShader
	{
		Tags{"RenderType" = "Opeque"}
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata //appdataという構造体を宣言
			{
				float4 vertex : POSITION;  //構造体にはセマンティクスが必要
				float3 normal : NORMAL;    //法線情報用のセマンティクス
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
			};

			v2f vert(appdata v)  //引数や返り値の構造体の中にセマンティクスが書かれているため、関数部分には不要
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal = mul(v.normal, (float3x3)unity_WorldToObject);
				//法線情報は頂点情報の中にあるので、fragに渡す必要がある。
				//ただし、モデルから受け取れる法線情報はモデルのローカル座標系なので、ワールド座標系の法線に変換する必要がある。
				return o;
			}

			fixed4 _Color;

			fixed4 frag(v2f i) : SV_Target
			{
				//面の法線と、光源の向きの内積を求める。
				//光源(太陽)がどの向きにあるかは、_WorldSpaceLightPos0から取得できる。
				//頂点から受け取った法線情報「i.normal」はここで標準化してください。
			   //float intensity = step((normalize(i.normal)),_WorldSpaceLightPos0)+ (1 - step((normalize(i.normal)),_WorldSpaceLightPos0))*0.5 + 0.5;
			   float intensity = smoothstep(0.45, 0.5, dot(normalize(i.normal), _WorldSpaceLightPos0)) + 0.5;

			//内積の値だけ明るくする
			//fixed4 r = distance(i.uv, fixed2(0.5, 0.5));
			return float4(intensity, intensity, intensity, 1)*_Color;
			//return smoothstep(intensity,intensity+0.02,r)
			//return o;
		 }



				//   fixed4 frag(float4 i:SV_POSITION) : SV_TARGET//画面描画用セマティングスは「SV_TARGET」floatが浮上少数に対して
				//  //fixedは座標少数。同じ小数を使用できる型
				   //{
				   //  fixed4 o = _Color;
				   //  return o;
				   //}
				   ENDCG
			   }
	}
}
