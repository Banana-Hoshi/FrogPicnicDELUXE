Shader "Custom/StandardSpecularPBR"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Tex("Texture", 2D) = "white" {}
        _Metallic("Metallic", Range(0,1)) = 0.0
        _SpecColor("Specular", Color) = (0,0,0,0)
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Geometry"
            }

            CGPROGRAM
            #pragma surface surf StandardSpecular

            sampler2D _Tex;
            half _Metallic;
            fixed4 _Color;

            struct Input
            {
                float2 uv_Tex;
            };

            void surf(Input IN, inout SurfaceOutputStandardSpecular o)
            {
                o.Albedo = tex2D(_Tex, IN.uv_Tex).rgb * _Color.rgb;
                o.Smoothness = tex2D(_Tex, IN.uv_Tex).r;
                o.Specular = _Metallic;
                o.Specular = _SpecColor.rgb;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
