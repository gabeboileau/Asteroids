Shader "Effects/SHD_Stars"
{
	Properties
	{
		_Color("Color", Color) = (1.0,1.0,1.0,1.0)
		_TexForceField("ForceField Texture",2D) = "white"{}
	}

		SubShader
		{
			Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
			Pass
		{

		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag
		uniform float4 _Color;
		uniform sampler2D _TexForceField;


	struct VertexInput
	{
		float4 vertex : POSITION;
		float3 texcoord : TEXCOORD0;

	};


	struct VertexOutput
	{
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};

	VertexOutput vert(VertexInput input)
	{
		VertexOutput output;
		output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
		output.uv = input.texcoord.xy;
		

		output.uv.x += _Time.x * 2;
		return output;
	}


	float4 frag(VertexOutput output) : COLOR
	{
		return tex2D(_TexForceField,output.uv);
	}

		ENDCG

	}


	}

}