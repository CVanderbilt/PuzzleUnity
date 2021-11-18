using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	private Color color;
	private void Start() {
		color = GetComponent<Renderer>().material.color;
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb == null)
			Debug.Log("Interactable objects must have a Rigidbody!!!");
	}

	public void MakeTransparent(bool t)
	{
		Debug.Log("making transparent");
		if (t == true)
			color.a = 0.5f;
		else
			color.a = 1;
		GetComponent<Renderer>().material.color = color;
	}
}
