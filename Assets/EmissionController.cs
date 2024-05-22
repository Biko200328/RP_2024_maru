using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionController : MonoBehaviour
{
	public Material emissiveMaterial;
	public Color activeColor = Color.red;
	public float intensity = 3.0f;

	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			// スペースキーを押している間、赤色に発光
			Color finalColor = activeColor * Mathf.LinearToGammaSpace(intensity);
			emissiveMaterial.SetColor("_EmissionColor", finalColor);
			DynamicGI.SetEmissive(GetComponent<Renderer>(), finalColor);
		}
		else
		{
			// スペースキーを離すと発光しない
			emissiveMaterial.SetColor("_EmissionColor", Color.black);
			DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.black);
		}
	}
}
