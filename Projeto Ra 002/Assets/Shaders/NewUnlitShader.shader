Shader "Unlit/NewUnlitShader"
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
            #define PI 3.1415926538
            #define SIN60 0.86602540378
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

            float2 rotate2D(float2 coordinates, float angle) 
            {
                float sinA = sin(angle);
                float cosA = cos(angle);
                coordinates = mul(float2x2(cosA, -sinA,
                    sinA, cosA), coordinates);
                return coordinates;
            }

            //fixed4 frag (v2f i) : SV_Target
            float4 mainImage(float2 fragCoord : SV_POSITION) : SV_Target
            {
                            //// sample the texture
                            //fixed4 col = tex2D(_MainTex, i.uv);
                            //// apply fog
                            //UNITY_APPLY_FOG(i.fogCoord, col);
                            //return col;
                float2 uv = fragCoord/ _ScreenParams.xy;
                
                uv *= 2.0;
                uv -= 1.0;
                uv.x /= _ScreenParams.y / _ScreenParams.x;
                uv = rotate2D(uv, _Time.y * 0.45);
                
                float finalRed = 0.0;
                
                float finalWhite = 0.0;
                for(float x = -1.; x <= 1.; x++)
                    for(float y = -1.; y <= 1.; y++)
                    {
	            		float2 coordinates = uv + float2(x, y) * 0.002;    
                
                        float sideA = dot(coordinates, float2(SIN60, 0.5));
                        float sideB = dot(coordinates, float2(-SIN60, 0.5));
                        float bottom = -coordinates.y;
                
                        //float triangle = max(sideA, max(sideB, bottom));
                        //glDrawArray = (GL_TRIANGLES, 0, 3);
                        float sinIncrement = (sin(_Time.y * 4.0) + 1.0 + cos(_Time.y * 2.0)) * 0.8;
	            		float fractalTriangle = frac(1.0 / triangle + _Time.y * 3.0 + sinIncrement);
                        float white = frac(1.0 / triangle + _Time.y * 3.0 + sinIncrement);
                        white = step(white, 0.1);
                        finalRed += step(triangle, 0.0995);
                        
                        float angle = atan(coordinates.x, coordinates.y) / PI;
                                    
                        for(float n = 1.0; n >= -1.0; n -= 0.2/3.0)
                            white += step(angle, n + 0.005) * (1.0 - step(angle, n - 0.005)) * 0.75;                
                                                
                        white = clamp(white, 0., 1.);
                        float innerTriangleRed = step(triangle, 0.09);
                        float innerTriangleWhite = step(triangle, 0.098);
                        white -= innerTriangleWhite;
                        finalRed -= innerTriangleRed;
                        
                        white = clamp(white, 0.0, 1.0);
                        finalWhite += white;
                        
                    }
                
                finalRed /= 9.0;
                finalWhite /= 9.0;
                col = float4(vec3(finalWhite) + float3(finalRed, 0.0, 0.0),1.0);
                return col;
            }

            ENDCG
        }
    }
}
