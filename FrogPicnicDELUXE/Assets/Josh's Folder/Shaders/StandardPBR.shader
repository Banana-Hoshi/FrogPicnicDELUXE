Shader "Custom/StandardPBR"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Tex("Texture", 2D) = "white" {}
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }

    SubShader
    {
        Tags 
        { 
            "Queue" = "Geometry"
        }

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _Tex;
        half _Metallic;
        fixed4 _Color;

        struct Input
        {
            float2 uv_Tex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = tex2D(_Tex, IN.uv_Tex).rgb * _Color.rgb;
            o.Metallic = _Metallic;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
