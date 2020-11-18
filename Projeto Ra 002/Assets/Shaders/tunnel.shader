Shader "Unlit/tunnel"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            const float n = 13.;
            const float k = 1.;


            float pattern(float2 p) {
                return 0.6 * pow(abs(sin(p.x * 3.141) * sin(p.y * 3.141)), 0.15);
            }

            //float4 mainImage(float2 fragCoord : SV_POSITION) : SV_Target
            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = (2. * i.uv - _ScreenParams.xy) / _ScreenParams.y;//fragCoord
                float tt = _Time.y * 0.5;
                float2 m;
                float cr = k * pow((sin(tt * 0.5) * 3.5 + 0.5), 1.0);
                m.x = atan2( i.uv.x, i.uv.y) / 6.283 * n;
                m.x += 1.5 * sin(length(uv) * cr + 3.141);
                m.x += tt;
                m.y = 3. * 1e2 / pow(length(uv), 1e-2);
                m.y += tt + m.x / n;
                m.y += sin(length(uv) * cr * 1.5);
                float coll = pattern(m);
                coll = float4(float3(coll, coll, coll), 1);
                fixed4 col = tex2D(_MainTex, coll);
                return col;
            }

            //fixed4 frag(v2f i) : SV_Target
            //{
            //    // sample the texture
            //    //fixed4 col = tex2D(_MainTex, i.uv);
            //    // apply fog
            //    //UNITY_APPLY_FOG(i.fogCoord, col);
            //    fixed4 col = coll;
            //    return col;
            //}
            ENDCG
        }
    }
}
