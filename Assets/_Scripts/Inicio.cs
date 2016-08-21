using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour {

	void Update()
	{
		if (Input.anyKey)
		{
			Application.LoadLevel("TransicionANegacion");
		}
	}
}
