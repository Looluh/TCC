Shader "Me/Dual_Textured_Transparent_11" {
	Properties {
		
		_Fade1 ("Fade 1", Range(0.0,1.0)) = 1.0
		_Fade2 ("Fade 2", Range(0.0,1.0)) = 1.0
		_Fade3 ("Fade 3", Range(0.0,1.0)) = 1.0
		_Fade4 ("Fade 4", Range(0.0,1.0)) = 1.0
		_Fade5 ("Fade 5", Range(0.0,1.0)) = 1.0
		_Fade6 ("Fade 6", Range(0.0,1.0)) = 1.0
		_Fade7 ("Fade 7", Range(0.0,1.0)) = 1.0
		_Fade8 ("Fade 8", Range(0.0,1.0)) = 1.0
		_Fade9 ("Fade 9", Range(0.0,1.0)) = 1.0
		_Fade10("Fade 10", Range(0.0,1.0)) = 1.0

		// standard
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		
		_Stencil("Stencil (A)", 2D) = "white"{}
		_Color1("Color 1", Color) = (1,1,1,1)
		_Tex1("Texture 1 (RGBA)", 2D) = "white" {}
		
		_Color2("Color 2", Color) = (1,1,1,1)
		_Tex2("Texture 2 (RGBA)", 2D) = "white"{}
		
		_Color3("Color 3", Color) = (1,1,1,1)
		_Tex3("Texture 3 (RGBA)", 2D) = "white"{}

		_Color4("Color 4", Color) = (1,1,1,1)
		_Tex4("Texture 4 (RGBA)", 2D) = "white"{}

		_Color5("Color 5", Color) = (1,1,1,1)
		_Tex5("Texture 5 (RGBA)", 2D) = "white"{}

		_Color6("Color 6", Color) = (1,1,1,1)
		_Tex6("Texture 6 (RGBA)", 2D) = "white"{}

		_Color7("Color 7", Color) = (1,1,1,1)
		_Tex7("Texture 7 (RGBA)", 2D) = "white"{}

		_Color8("Color 8", Color) = (1,1,1,1)
		_Tex8("Texture 8 (RGBA)", 2D) = "white"{}

		_Color9("Color 9", Color) = (1,1,1,1)
		_Tex9("Texture 9 (RGBA)", 2D) = "white"{}

		_Color10("Color 10", Color) = (1,1,1,1)
		_Tex10("Texture 10 (RGBA)", 2D) = "white"{}

		_Lightup("Lightup", Range(0.0,1.0)) = 0.0

	}
	SubShader {
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows alpha:fade
		#pragma target 4.5

		fixed4 _Color1;
		fixed4 _Color2;
		fixed4 _Color3;
		fixed4 _Color4;
		fixed4 _Color5;
		fixed4 _Color6;
		fixed4 _Color7;
		fixed4 _Color8;
		fixed4 _Color9;
		fixed4 _Color10;

		sampler2D _Tex1;
		sampler2D _Stencil;
		sampler2D _Tex2;
		sampler2D _Tex3;
		sampler2D _Tex4;
		sampler2D _Tex5;
		sampler2D _Tex6;
		sampler2D _Tex7;
		sampler2D _Tex8;
		sampler2D _Tex9;
		sampler2D _Tex10;

    	float _Fade1;
    	float _Fade2;
		float _Fade3;
		float _Fade4;
		float _Fade5;
		float _Fade6;
		float _Fade7;
		float _Fade8;
		float _Fade9;
		float _Fade10;

		float _Lightup;

    	// Standard
    	half _Glossiness;
		half _Metallic;

		struct Input {
			float2 uv_Tex1;
			float2 uv_Stencil;
			float2 uv_Tex2;
			float2 uv_Tex3;
			float2 uv_Tex4;
			float2 uv_Tex5;
			float2 uv_Tex6;
			float2 uv_Tex7;
			float2 uv_Tex8;
			float2 uv_Tex9;
			float2 uv_Tex10;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
		
			half4 FirstColor = tex2D(_Tex1, IN.uv_Tex1); 
			half4 SecondColor = tex2D(_Tex2, IN.uv_Tex2); 
			half4 ThirdColor = tex2D(_Tex3, IN.uv_Tex3);
			half4 FourthColor = tex2D(_Tex4, IN.uv_Tex4);
			half4 FifthColor = tex2D(_Tex5, IN.uv_Tex5);
			half4 SixthColor = tex2D(_Tex6, IN.uv_Tex6);
			half4 SeventhColor = tex2D(_Tex7, IN.uv_Tex7);
			half4 EighthColor = tex2D(_Tex8, IN.uv_Tex8);
			half4 NinethColor = tex2D(_Tex9, IN.uv_Tex9);
			half4 Tenth = tex2D(_Tex10, IN.uv_Tex10);

			float Stencil = tex2D(_Stencil, IN.uv_Stencil).a;	
			float Opposite_stencil = 1.0-Stencil;
			
			float first_stencil_value = (Stencil * _Fade1);// + (Opposite_stencil * (1 - _Fade2));
			float second_stencil_value = (Stencil * _Fade2);// + (Opposite_stencil * (1 - _Fade3));//(Opposite_stencil * _Fade2) + (Stencil * (1-_Fade1));
			float third_stencil_value = (Stencil * _Fade3);// + (Opposite_stencil * (1 - _Fade4));
			float fourth_stencil_value = (Stencil * _Fade4);
			float fifth_stencil_value = (Stencil * _Fade5);
			float sixth_stencil_value = (Stencil * _Fade6);
			float seventh_stencil_value = (Stencil * _Fade7);
			float eighth_stencil_value = (Stencil * _Fade8);
			float nineth_stencil_value = (Stencil * _Fade9);
			float tenth_stencil_value = (Stencil * _Fade10);

			o.Albedo = (FirstColor.rgb * _Color1.rgb * first_stencil_value) + 
					   (SecondColor.rgb * _Color2.rgb * second_stencil_value) + 
				       (ThirdColor.rgb * _Color3.rgb * third_stencil_value) +
			           (FourthColor.rgb * _Color4.rgb * fourth_stencil_value) +
				       (FifthColor.rgb * _Color5.rgb * fifth_stencil_value) +
				       (SixthColor.rgb * _Color6.rgb * sixth_stencil_value) +
				       (SeventhColor.rgb * _Color7.rgb * seventh_stencil_value) +
				       (EighthColor.rgb * _Color8.rgb * eighth_stencil_value) +
				       (NinethColor.rgb * _Color9.rgb * nineth_stencil_value) +
				       (Tenth.rgb * _Color10.rgb * tenth_stencil_value);

			o.Alpha = (FirstColor.a * _Color1.a * first_stencil_value) + 
					  (SecondColor.a * _Color2.a * second_stencil_value) +
				      (ThirdColor.a * _Color3.a * third_stencil_value) +
			          (FourthColor.a * _Color4.a * fourth_stencil_value) +
				      (FifthColor.a * _Color5.a * fifth_stencil_value) +
				      (SixthColor.a * _Color6.a * sixth_stencil_value) +
				      (SeventhColor.a * _Color7.a * seventh_stencil_value) +
				      (EighthColor.a * _Color8.a * eighth_stencil_value) +
				      (NinethColor.a * _Color9.a * nineth_stencil_value) +
				      (Tenth.a * _Color10.a * tenth_stencil_value);
			
			//o.Emission = (FirstColor.rgb * _Color1.rgb * first_stencil_value) + (SecondColor.rgb * _Color2.rgb * second_stencil_value);
			o.Emission = (_Lightup * _Color1.rgb * _Color2.rgb * _Color3.rgb * _Color4.rgb * _Color5.rgb * _Color6.rgb * _Color7.rgb * _Color8.rgb * _Color9.rgb * _Color10.rgb);// * _Color10.rgb

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
	
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
