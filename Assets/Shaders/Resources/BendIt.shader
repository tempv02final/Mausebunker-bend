Shader "Unlit/BendIt"
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
            #pragma vertex   vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv     : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

			#define PI  3.14159265359
            sampler2D   _MainTex;
            float4      _MainTex_ST;
			float4x4    _WorldToOrigin;
			float4x4    _OriginToWorld;
			float       beginingDistance;
			float       maxDistance;
			float       stretchInY;

            v2f vert (appdata v)
            {
                v2f o;

				float4 vVertex = mul(unity_ObjectToWorld, v.vertex);
				       vVertex = mul(_WorldToOrigin, vVertex);

				float  theta   = smoothstep(beginingDistance, maxDistance, max(0., vVertex.z));
				       theta  *= -(sin(_Time.x*2.) + 1.) / 2.;
				       theta  *= PI;

			    float  yMultiplyer = vVertex.z*-theta* stretchInY;
			
				float4x4 rotationM = float4x4( 1.,         0.,          0.,          0.,
					                           0., cos(theta), -sin(theta), yMultiplyer,
					                           0., sin(theta),  cos(theta),          0.,
					                           0.,         0.,          0.,          1.);
					
				 vVertex = mul(rotationM, vVertex);
				 vVertex = mul(_OriginToWorld, vVertex);
                o.vertex = mul(UNITY_MATRIX_VP ,vVertex);

                o.uv     = TRANSFORM_TEX(v.uv, _MainTex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                return col;
            }
            ENDCG
        }
    }
}
