// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/orangespiral"
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
            #define PI 3.14159265359
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
                float4 scrCen : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.scrCen = o.vertex / o.vertex.w;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);

                                // Compute the center of the tunnel
                float4 objectOrigin = mul(unity_ObjectToWorld, i.vertex);
                //float2 center = ((i.uv/2) / _ScreenParams.xy) * 2.0 - 1.0;//fragCoord.xy
                float2 center = (2 * i.uv) - 2 / 2;//meio da uv
                // Fix aspect ratio
                center.x = mul((_ScreenParams.x / _ScreenParams.y), center.x);

                // Animate the center of the tunnel
                center.x += sin(_Time) * 0.2;
                center.y += cos(_Time) * 0.15;

                // Generate the tunnel stripes
                float a = (1. / length(center) + atan2(center.y, center.x) / PI * 1.0 + _Time) * 2;
                float b = (sin(a * PI * 8.) * dot(center, center) * _ScreenParams.y / 150. - 0.3);
                float c = (b * sin(length(center) - .1)) *2;

                fixed4 coll = lerp(float4(0, 0, 0, 1), float4(0.5, 0.25, 0, 1), c);//fragColor
                //fixed4 fragColor = float4(1,1,1,1);
                //fragColor.rgb = float3(1, 1, 1);
                //fragColor.a = float(1);
                //return fragColor;
                return coll;
                //return col;
            }
            ENDCG
        }
    }
}
