Shader "Unlit/XrayVision"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _RampTex("Texture", 2d) = "white" {}
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

                    output.pos = UnityObjectToClipPos(input.vertex);

                    float4 normal4 = float4(input.normal, 0.0);

                    output.normal = normalize(mul(normal4, unity_WorldToObject).xyz);

                    output.texCoord = input.texCoord;

                    TRANSFER_VERTEX_TO_FRAGMENT(output);

                    return output;
                }

                float4 frag(vertOutput input)  : COLOR
                {

                    float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                    float ramp = clamp(dot(input.normal, lightDir), 0, 1.0);
                    float3 lighting = tex2D(_RampTex, float2(ramp, 0.5)).rgb;

                    float4 albedo = tex2D(_MainTex, input.texCoord.xy);

                    float attenuation = LIGHT_ATTENUATION(input);

                    float3 rgb = albedo.rgb * _LightColor0.rgb * lighting * attenuation;
                    return float4(rgb, 1.0);


                }

                ENDCG

            }

            Pass

                {
                    Tags
                    {
                        "LightMode" = "ShadowCaster"
                    }

                    CGPROGRAM

                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma multi_compile_shadowcaster
                    #include "UnityCG.cginc"

            struct v2f
            {
                    V2F_SHADOW_CASTER;
            };


            v2f vert(appdata_base v)
            {
                v2f o;

                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o);

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {

                SHADOW_CASTER_FRAGMENT(i)
            }
                ENDCG
            }


                Pass

            {

                Tags {
                    "Queue" = "Transparent"
                     }

                Cull Front
                ZWrite Off
                ZTest Always


                Stencil {

                    Ref 3
                    Comp Greater
                    Fail keep
                    Pass replace

                }

                Blend SrcAlpha OneMinusSrcAlpha


                CGPROGRAM

                #pragma vertex vert
                #pragma fragment frag

                uniform float4 _Color;

            struct vertInput {
                float4 vertex : POSITION;
            };

            struct vertOutput {
                float4 pos : SV_POSITION;
            };


            vertOutput vert(vertInput input) {

                vertOutput output;

                output.pos = UnityObjectToClipPos(input.vertex);

                return output;
                }

            float4 frag(vertOutput input) : COLOR
            {
                return _Color;
            }


                ENDCG
            }


        }

        Pass
        {
            Tags
            {
                "Queue" = "Transparent"
            }


            Cull Back
            ZWrite Off
            ZTest Always


            Stencil
            {
                Ref 4
                Comp NotEqual
                Pass keep
            }

            Blend SrcAlpha OneMinusSrcAlpha

            CGProgram
            #pragma vertex vert 
            #pragma fragment frag

            uniform float4 _Color;

            struct vertInput {
                float4 vertex : POSITION;
                };

            struct vertOutput {
                 float4 pos : SV_POSITION;
             };


        vertOutput vert(vertInput input) {
            vertOutput output;

            output.pos = UnityObjectToClipPos(input.vertex);

            return output;
        }

        float4 frag(vertOutput input) : COLOR{
            return _Color;
        }

            ENDCG
        }
}
