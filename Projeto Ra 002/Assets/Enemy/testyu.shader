Shader "Custom/testyu"
{
    Properties
    {
        //_Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0

        _ColorLight("ColorLight", Color) = (0,1,0,0)
        [HDR]_EmissionColor("EmissionColor", Color) = (0,0,0)
        _EmissionMap("Emission", 2D) = "white" {}

    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
        #pragma shader_feature _EMISSION
                    #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"
            #include "AutoLight.cginc"

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
         //           #pragma shader_feature _EMISSION
         //
         //   #include "UnityCG.cginc"
         //   #include "UnityLightingCommon.cginc"
         //   #include "AutoLight.cginc"

        sampler2D _MainTex;
        sampler2D _EmissionMap;

        struct Input
        {
            float2 uv_MainTex;
            float4 norm : NORMAL;
            float2 uv_EmissiveMap;

        };

        half _Glossiness;
        half _Metallic;
        //fixed4 _Color;
        float4 _ColorLight;
        float4 _EmissionColor;
        float4 _EmissionMap_ST;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);// * _Color
            fixed4 faf = tex2D(_EmissionMap, IN.uv_EmissiveMap);
            float ilumin = max(dot(IN.norm, _WorldSpaceLightPos0), 0);
            o.Albedo = ((max((c), 0) * _ColorLight) + (faf * _EmissionColor));

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
