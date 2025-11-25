Shader "Custom/SoftGlow"
{
   Properties
   {
       _MainTex("Sprite Texture", 2D) = "white" {}
       _GlowColor("Glow Color", Color) = (1,1,1,1)
       _GlowSize("Glow Size", Range(0.0, 0.1)) = 0.03
   }
   SubShader
   {
       Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" "CanUseSpriteAtlas"="True" }
       LOD 100
       Blend SrcAlpha OneMinusSrcAlpha
       ZWrite Off
       Cull Off
       Pass
       {
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
           #include "UnityCG.cginc"
           sampler2D _MainTex;
           float4 _MainTex_ST;
           float4 _GlowColor;
           float _GlowSize;
           struct appdata
           {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
           };
           struct v2f
           {
               float4 vertex : SV_POSITION;
               float2 uv : TEXCOORD0;
           };
           v2f vert (appdata v)
           {
               v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
               o.uv = TRANSFORM_TEX(v.uv, _MainTex);
               return o;
           }
           fixed4 frag (v2f i) : SV_Target
           {
               float4 col = tex2D(_MainTex, i.uv);
               float glow = 0.0;
               float2 offsets[8] = {
                   float2(-_GlowSize, 0), float2(_GlowSize, 0),
                   float2(0, -_GlowSize), float2(0, _GlowSize),
                   float2(-_GlowSize, -_GlowSize), float2(-_GlowSize, _GlowSize),
                   float2(_GlowSize, -_GlowSize), float2(_GlowSize, _GlowSize)
               };
               for (int n = 0; n < 8; n++)
               {
                   glow += tex2D(_MainTex, i.uv + offsets[n]).a;
               }
               col.rgb += (_GlowColor.rgb * glow * 0.1);
               return col;
           }
           ENDCG
       }
   }
}