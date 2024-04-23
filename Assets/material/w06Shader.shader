// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader "Unlit/w06Shader"
{
    Properties
    {
        _DiffuseColor("DiffuseColor",Color) = (1,1,1,1)
        _LightDirection("LightDirection",Vector) = (1,-1,-1,0)
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
                float3 normal : NORMAL;
            };

            float4 _DiffuseColor;
            float4 _LightDirection;
            float3 _WorldSpaceCameraPos0;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float lightDIr = normalize(_LightDirection);
                float lightIntensity = max(dot(i.normal,lightDIr),0);

                float3 reflectDir = reflect(-_WorldSpaceLightPos0.xyz, normalize(i.normal));//입사각과 법선벡터를 기준으로 반사각 계산
                float obj2camDir = dot(normalize(-_WorldSpaceCameraPos0.xyz),reflectDir);//물체에서 눈으로 들어오는 빛 각도 계산
                float Spec = pow(max(obj2camDir,0),32);

                float col = _DiffuseColor + lightIntensity + Spec;
                float final = floor(col*4.3)/4.3;
                return final;
            }
            ENDCG
        }
    }
}
