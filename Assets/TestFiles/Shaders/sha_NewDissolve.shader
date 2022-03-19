Shader "Unlit/sha_NewDissolve"
{
    Properties
    {
	
		[Header(Albedo Color)]

		[Space(10)]

		[HDR]_Color ("Color", Color) = (1,1,1,1)

		
		[Header(Albedo Texture)]
		
		[Space(10)]

        _MainTex ("Main Texture", 2D) = "white" {}
		
		[Space(10)]

		[Header(Math Texture)]
		
		[Space(10)]

        _DissTex ("Alpha Texture", 2D) = "white" {}
		//_Cutout ("Dissolve", Range(0,1)) = 0.5
		//[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("SrcBlend", float) = 5
		//[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("DstBlend", float) = 10
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		
		Blend SrcAlpha OneMinusSrcAlpha
		//Blend [SrcBlend] [DstBlend]



		Cull off

		ZWrite off

        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 uv : TEXCOORD0;
				float4 color : COLOR;

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float4 color : COLOR;
                float4 vertex : SV_POSITION;
				float Custom : TEXCOORD1;

				//float CustomData : TEXCOORD1;
            };

			float4 _Color;
            sampler2D _MainTex;
            sampler2D _DissTex;
            float4 _MainTex_ST;
			float _Cutout;

            v2f vert (appdata v)
            {
                v2f o;
				o.color = v.color;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv.xy, _MainTex);
				o.Custom = v.uv.z;
                UNITY_TRANSFER_FOG(o,o.vertex);

				//o.CustomData = v.uv.z;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				//float CD = i.CustomData;

                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                fixed4 dis = tex2D(_DissTex, i.uv);

				col.w *= step(i.Custom, dis.x);
                return col *= i.color;
            }
            ENDCG
        }
    }
}
