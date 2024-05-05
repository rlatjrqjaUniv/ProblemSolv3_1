Shader"Custom/cartoonShader"
{
    Properties
    {
        _Color("Color",Color) = (1,1,1,1)
        _lightStr("Deffuse",float) = 0.3
        _Level("Level",float) = 4.3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            float4 _Color;
            float _lightStr;
            float3 _WorldSpaceCameraPos0;
            float3 _WorldSpaceLightDir0;
            float _Level;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 ambient = _lightStr * float3(1,1,1);
    
                //float lightDIr = normalize(_WorldSpaceLightDir0); //_WorldSpaceLightPos0.xyz - i.normal
                float lightIntensity = max(dot(normalize(i.normal), normalize(_WorldSpaceLightPos0.xyz)), 0.45);

                float3 reflectDir = reflect(-_WorldSpaceLightPos0.xyz, normalize(i.normal));
                float obj2camDir = dot(normalize(-_WorldSpaceCameraPos0.xyz), reflectDir);
                float Spec = pow(max(obj2camDir,0), 32);

                float col = ambient + lightIntensity + Spec;
                float final = floor(col * _Level) / _Level;
                return _Color * final;
            }
            ENDCG
        }
    }
}