Shader "Unlit/XrayVision"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RampTex("Texture", 2d) = "black" {}
        _DrawColor("Draw Color", Color) = (0, 0, 0, 1)
    }

        SubShader
        {
            Pass
            {
                Tags {
                    "LightMode" = "ForwardBase"
                }

                Stencil
                {
                    Ref 4
                    Comp always
                    Pass replace
                    ZFail keep
                }

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #pragma multi_compile_fwdbase 

                #include "AutoLight.cginc"
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                sampler2D _RampTex;


                float4 _LightColor0;


                struct vertInput {

                    float4 vertex : POSITION;
                    float3 normal : NORMAL;
                    float3 texCoord : TEXCOORD0;
                };


                struct vertOutput {
                    float4 pos : SV_POSITION;
                    float3 normal : NORMAL;
                    float3 texCoord :TEXCOORD0;
                    LIGHTING_COORDS(1, 2)
                };


                vertOutput vert(vertInput input) {

                    vertOutput output;









                    return output;
                }



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

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
