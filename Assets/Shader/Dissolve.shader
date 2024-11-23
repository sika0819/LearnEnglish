Shader "Custom/DissolveURP"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DissolveTex("DissolveTex", 2D) = "white" {}
        _DissolveThreshold("DissolveThreshold", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D(_DissolveTex);
            SAMPLER(sampler_DissolveTex);
            float _DissolveThreshold;

            Varyings vert(Attributes IN)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(IN.positionOS);
                o.uv = IN.uv;
                return o;
            }
            
            half4 frag(Varyings IN) : SV_Target
            {
                half4 dissolveCol = SAMPLE_TEXTURE2D(_DissolveTex, sampler_DissolveTex, IN.uv);
                clip(dissolveCol.r - _DissolveThreshold);

                half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                return col;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/Universal Render Pipeline/FallbackError"
}