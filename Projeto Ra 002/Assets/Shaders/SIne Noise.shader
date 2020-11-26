Shader "Unlit/Sine Noise"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #define m3 float3x3(-0.73736, 0.45628, 0.49808, 0, -0.73736, 0.67549, 0.67549, 0.49808, 0.54371)
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _Grayscale;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                //float3 q = float3(uv, _Time, 1);
                float2 uv = (2 * i.uv) - 2 / 2;//meio do polígono, equivale a //= fragCoord / iResolution.y;
                float3 q = float3(uv, _Time.y * 0.2);
                float3 c = float3(0, 0, 0);
                for (int a = 0; a < 8; a++) 
                {
                    q = mul(m3, q);
                    float3 s = sin(q.zxy);
                    q += s * 2.;
                    c += s;
                }
                float ca = c.x * 0.5;
                float cb = c.y * 0.5;
                float cc = c.z * 0.5;

                fixed4 fragColor = float4(lerp(float3(ca, cb, cc), c, 0.5) * .15 + .5, 1.);
                return dot((fragColor * col * _Color), float3(0.3, 0.59, 0.11));//remover o dot e o float3 pra deixar com cor: 
                                                                                //return fragColor*col*_Color;
                //return col;                                                   //col funciona como um stencyl
            }
            ENDCG
        }
    }
}
