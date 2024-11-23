Shader "Unlit/Shadow"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _lineWidth("lineWidth",Range(0,20))=10
        _lineColor("lineColor",Color)=(0,0,0,1)
        
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

            struct VertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct VertexOutput
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            

            VertexOutput vert (VertexInput v)
            {
                VertexOutput o;
                o.vertex = TransformObjectToHClip(v.vertex);
                o.uv = v.uv;
                return o;
            }
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _lineWidth;
            float4 _lineColor;
            float4 frag (VertexOutput i) : SV_Target
            {
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
                float2 up_uv = i.uv +float2(0,1)*_lineWidth*_MainTex_TexelSize.xy;
                float2 down_uv = i.uv +float2(0,-1)*_MainTex_TexelSize.xy;
                float2 left_uv = i.uv +float2(-1,0)*_lineWidth*_MainTex_TexelSize.xy;
                float2 right_uv = i.uv +float2(1,0)*_MainTex_TexelSize.xy;
                float w = tex2D(_MainTex,up_uv).a*tex2D(_MainTex,down_uv).a*tex2D(_MainTex,left_uv).a*tex2D(_MainTex,right_uv).a;
                col.rgb =lerp(_lineColor,col.rgb,w);
                return col;
            }
            ENDHLSL
        }
    }
}
