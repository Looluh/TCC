Shader "DUAL/Dual_Textured_Transparent" {
	Properties {
		
		_Fade1 ("Fade 1", Range(0.0,1.0)) = 1.0
		_Fade2 ("Fade 2", Range(0.0,1.0)) = 1.0
		_Fade3 ("Fade 3", Range(0.0,1.0)) = 1.0
		_Fade4 ("Fade 4", Range(0.0,1.0)) = 1.0

		// standard
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		
		_Stencil("Stencil (A)", 2D) = "white"{}
		_Color1 ("Color 1", Color) = (1,1,1,1)
		_Tex1 ("Texture 1 (RGBA)", 2D) = "white" {}
		
		_Color2 ("Color 2", Color) = (1,1,1,1)
		_Tex2("Texture 2 (RGBA)", 2D) = "white"{}
		
		_Color3 ("Color 3", Color) = (1,1,1,1)
		_Tex3("Texture 3 (RGBA)", 2D) = "white"{}

		_Lightup("Lightup", Range(0.0,1.0)) = 0.0

	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:fade
		#pragma target 3.0

		fixed4 _Color1;
		fixed4 _Color2;
		fixed4 _Color3;
		sampler2D _Tex1;
		sampler2D _Stencil;
		sampler2D _Tex2;
		sampler2D _Tex3;

    	float _Fade1;
    	float _Fade2;
		float _Fade3;
		float _Fade4;

		float _Lightup;

    	// Standard
    	half _Glossiness;
		half _Metallic;

		struct Input {
			float2 uv_Tex1;
			float2 uv_Stencil;
			float2 uv_Tex2;
			float2 uv_Tex3;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
		
			half4 FirstColor = tex2D(_Tex1, IN.uv_Tex1); 
			half4 SecondColor = tex2D(_Tex2, IN.uv_Tex2); 
			half4 ThirdColor = tex2D(_Tex3, IN.uv_Tex3);

			float Stencil = tex2D(_Stencil, IN.uv_Stencil).a;	
			float Opposite_stencil = 1.0-Stencil;
			
			float first_stencil_value = (Stencil * _Fade1);// + (Opposite_stencil * (1 - _Fade2));
			float second_stencil_value = (Stencil * _Fade2);// + (Opposite_stencil * (1 - _Fade3));//(Opposite_stencil * _Fade2) + (Stencil * (1-_Fade1));
			float third_stencil_value = (Stencil * _Fade3);// + (Opposite_stencil * (1 - _Fade4));

			o.Albedo = (FirstColor.rgb * _Color1.rgb * first_stencil_value) + 
					   (SecondColor.rgb * _Color2.rgb * second_stencil_value) + (ThirdColor.rgb * _Color3.rgb * third_stencil_value);
					   
			o.Alpha = (FirstColor.a * _Color1.a * first_stencil_value) + 
					  (SecondColor.a * _Color2.a * second_stencil_value) + (ThirdColor.a * _Color3.a * third_stencil_value);
			
			//o.Emission = (FirstColor.rgb * _Color1.rgb * first_stencil_value) + (SecondColor.rgb * _Color2.rgb * second_stencil_value);
			o.Emission = (_Lightup * _Color1.rgb * _Color2.rgb * _Color3.rgb);

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
	
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
