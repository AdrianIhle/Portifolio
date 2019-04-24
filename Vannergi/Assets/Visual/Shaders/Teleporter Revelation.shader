// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

  //Flat color texture, does not support alpha channels
     Shader "SFX/Teleporter Revalation"
     {
         Properties
         {
		      _Color ("Main Color", Color) = (1,1,1,1)
             _MainTex ( "Main Texture", 2D ) = "white" {}

			 _RotSpeed ("Rotation Speed", Range(0, 20)) = 1
				   _Cutoff ("Alpha cutoff", Range (0,1)) = 0.0

         }
         
         SubShader
         {  
		 
		 Pass{
		  
		 ZWrite On
		 ZTest Less     //Less
		 Lighting Off
		 Cull Off
			AlphaTest GEqual [_Cutoff]

           
				 SetTexture [_MainTex] {
				     combine constant, texture
				 }
			}



             Pass
	         {
			Tags { "RenderType" = "Transparent+ 1" "Queue" = "Transparent + 1" "IgnoreProjector" = "True" "ForceNoShadowCasting" = "True"}
		 //ZWrite Off
		 ZTest /*Equal*/	    /* Greater*/ GEqual
		 Lighting Off
		 Cull Off
		 Blend SrcColor OneMinusSrcColor
			     CGPROGRAM
			     #pragma vertex vert
			     #pragma fragment frag
			     
			     #include "UnityCG.cginc"
			     
			     
			     // uniforms
			     uniform sampler2D _MainTex;
				 uniform float _RotSpeed;
			     //LOOK! The texture name + ST is needed to get the tiling/offset
			     uniform float4 _MainTex_ST;
				 uniform float _AlphaValue;
			     
			     
			     struct vertexInput
			     {
			         float4 vertex : POSITION; 
			         float4 texcoord : TEXCOORD0;
					 float4 color :COLOR;
			     };
			     
			     
			     struct fragmentInput
			     {
			         float4 pos : SV_POSITION;
					 float4 color : COLOR;
			         half2 uv : TEXCOORD0;
			     };
			     
			     
			     fragmentInput vert( vertexInput i )
			     {
			         fragmentInput o;
			         o.pos = UnityObjectToClipPos( i.vertex );
			 
					//This is a standard defined function in Unity, 
					//Does exactly the same as the next line of code
					        //o.uv = TRANSFORM_TEX( i.texcoord, _MainTex );
					    
					//LOOK! _MainTex_ST.xy is tiling and _MainTex_ST.zw is offset
					//Important! need to set the tex offsett to not zero to work
			         o.uv =  i.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw*_Time* _RotSpeed;
					 o.color = float4(i.color.rgb, 0.3);
			         return o;
			     }
			     
			     
			     half4 frag( fragmentInput i ) : COLOR
			     {
			         return half4( tex2D( _MainTex, i.uv ).rgb, 0.2);
			     }
			     
			     ENDCG
          } // end Pass

//		  		 		 //IgnoreProjector set to true due to being semitransparent, proejectors dont act nice with semitransparent, just a precaution
//             Tags { "RenderType" = "Geometry " "Queue" = "Geometry" "ForceNoShadowCasting" = "True"}
//             ZWrite Off	
//			 Lighting Off
//			 Cull Back
//             Blend SrcColor OneMinusSrcColor
//			 
//		         Pass {         
//            AlphaTest Greater [_Cutoff]
//            //ZWrite Off
//            //ZTest Greater
//           
//            SetTexture [_MainTex] {
//                combine constant, texture
//            }
//        } 
//				CGPROGRAM
//				#pragma surface surf Ramp alphatest:_Cutoff
//				 
//				uniform float4 _Color;
//				uniform sampler2D _BumpTex;
//				uniform sampler2D _WrapTex;
//				 
//				half4 LightingRamp (SurfaceOutput s, half3 lightDir, half atten) {
//				    half4 c;
//				    c.rgb = s.Albedo /** _LightColor0.rgb * ramp*/;
//				    c.a = s.Alpha;
//									//    half NdotL = dot (s.Normal, lightDir);
//				//    half diff = NdotL * 0.5 + 0.5;
//				//    half3 ramp = tex2D (_WrapTex, float2(0.1,0.5)).rgb;
//				    return c;
//				}
//				 
//				struct Input {
//				    float2 uv_BumpTex;
//				    float2 uv_BumpMap;
//				    float3 viewDir;
//				};
//				 
//				void surf (Input IN, inout SurfaceOutput o) {
//				    o.Albedo = tex2D ( _BumpTex, IN.uv_BumpTex).rgb;
//				    o.Alpha = tex2D ( _BumpTex, IN.uv_BumpTex).a;
//									 //   half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
//				//    o.Emission += tex2D ( _MainTex, IN.uv_MainTex).rgb  * pow (rim, 100.0);
//				}
//				ENDCG
//				 
//	


         } // end SubShader


         
         FallBack "Diffuse"
     }