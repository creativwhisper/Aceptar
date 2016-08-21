using UnityEngine;
using System.Collections;

public class Depression : MonoBehaviour 
{
	
	public Transform environment;
	public Camera view;

	private Rigidbody controller;


	public Vector3 deepScale = new Vector3(5, 5, 5);
	public float exponentialDepres = 20;

	private Vector3 linInc;
	private float expInc;
	private int crechendo = 0;

	private RaycastHit hit;
	private Ray ray;

	// [SpecificInInspector]

	void Start ()
	{
		
		controller = GetComponent<Rigidbody>();
	}


	void Update () 
	{
		
		/*
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			if (Physics.Raycast(transform.position, fwd, 10)) {
				print("There is something in front of the object!");
			}
			*/
	}

	void FixedUpdate ()
	{
		
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		ray = view.ScreenPointToRay(new Vector3(x,y));
		
		
		if (!Physics.Raycast(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("exit")) )
		{
			if( controller.velocity != new Vector3 (0,0,0) )
			{
				
				linInc = deepScale * (controller.velocity).magnitude / 100000000;
				expInc = exponentialDepres/10000;
				
				environment.localScale += linInc;
				environment.localScale *= expInc + 1;
				
				if( view.fieldOfView < 120 )
				{
					
					view.fieldOfView += linInc.magnitude;
					view.fieldOfView *= expInc/10 + 1;
				}
			}
		}
		
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "exit") {
			Application.LoadLevel("0.5 Aceptacion");
		}
	}
}
