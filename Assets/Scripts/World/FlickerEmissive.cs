using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEmissive : MonoBehaviour {
	public float Minimum = 2.5f;
	public float Maxmimum = 4.0f;
	Renderer rend;
	Color col;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		col = rend.material.GetColor("_EmissionColor");
		InvokeRepeating("Flicker", 0, 0.05f);
	}

	// Update is called once per frame
	void Flicker () {
		Color NewCol = col * Random.Range(Minimum, Maxmimum);
		rend.material.SetColor("_EmissionColor", NewCol);
	}
}