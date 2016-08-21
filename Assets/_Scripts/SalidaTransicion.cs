using UnityEngine;
using System.Collections;

public class SalidaTransicion : MonoBehaviour {

	public float time;
	private float timeCount;

	void Update()
		{
		timeCount += Time.deltaTime;

		if (timeCount > time)
			{
			Application.LoadLevel("0.1 Negacion");
			}
}
}
