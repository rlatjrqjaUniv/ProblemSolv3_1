// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

// Upgrade NOTE: commented out 'float3 _WorldSpaceCameraPos', a built-in variable

Shader"Unlit/w06Shader"
{
    Properties
    {
        _DiffuseColor("DiffuseColor",Color) = (1,1,1,1)
        _LightDirection("LightDirection",Vector) = (1,-1,-1,0)
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

float4 _DiffuseColor;
float4 _LightDirection;
float3 _WorldSpaceCameraPos0;
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
    float lightDIr = normalize(_LightDirection); //_WorldSpaceLightPos0.xyz - i.worldPos
    float lightIntensity = max(dot(i.normal, lightDIr), 0);

    float3 reflectDir = reflect(-_WorldSpaceLightPos0.xyz, normalize(i.normal)); //�Ի簢�� �������͸� �������� �ݻ簢 ���
    float obj2camDir = dot(normalize(-_WorldSpaceCameraPos0.xyz), reflectDir); //��ü���� ������ ������ �� ���� ���
    float Spec = pow(max(obj2camDir, 0), 32);

    float col = _DiffuseColor + lightIntensity + Spec;
    float final = floor(col * _Level) / _Level;
    return final;
}
            ENDCG
        }
    }
}