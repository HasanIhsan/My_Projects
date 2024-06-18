sampler2D input : register(s0);
float2 center : register(c0);
float time : register(c1);
float amplitude : register(c2);
float frequency : register(c3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 texCoord = uv;
    float2 toCenter = texCoord - center;
    float dist = length(toCenter);
    float ripple = sin(dist * frequency - time) * amplitude;
    texCoord += ripple * normalize(toCenter);
    return tex2D(input, texCoord);
}
