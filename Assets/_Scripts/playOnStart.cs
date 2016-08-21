using UnityEngine;
using System.Collections;

public class playOnStart : MonoBehaviour {

	private float  timeCount=0;
	// Use this for initialization
	void Start(){
		((MovieTexture)GetComponent<Renderer> ().material.mainTexture).Play ();
	}

	void Update(){
		timeCount += Time.deltaTime;
		if (timeCount > 45)
			Application.LoadLevel ("0.0 Inicio");
	}
}
