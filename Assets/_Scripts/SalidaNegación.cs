using UnityEngine;
using System.Collections;

public class SalidaNegación : MonoBehaviour {

	void OnTriggerExit(Collider other) {
			Application.LoadLevel("0.2 Ira");
		}
}
