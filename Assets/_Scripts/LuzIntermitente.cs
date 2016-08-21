using UnityEngine;
using System.Collections;

public class LuzIntermitente : MonoBehaviour {

	public float timer;
	public float time;
	private Light l;

	void Start () {
		l = GetComponent<Light> ();
	}

	void FixedUpdate () {
		timer -= Time.deltaTime * time;
		if (timer <= 2)
		{
		l.enabled = !l.enabled;
		timer = 0;
		}
		
	}
}
