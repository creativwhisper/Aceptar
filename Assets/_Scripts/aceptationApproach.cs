using UnityEngine;
using System.Collections;

public class aceptationApproach : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "exit")
			Application.LoadLevel ("Creditos");
	}
}
