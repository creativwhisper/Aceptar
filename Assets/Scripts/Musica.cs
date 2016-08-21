using UnityEngine;
using System.Collections;

public class Musica : MonoBehaviour
{

	void Awake()
	{

		DontDestroyOnLoad (transform.gameObject);
	}

    void OnTriggerEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
