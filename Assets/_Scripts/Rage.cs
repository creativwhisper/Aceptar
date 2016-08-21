using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
	

public class Rage : MonoBehaviour 
{

	private List< List<GameObject> > matrixEnviron = new List< List<GameObject> >();

	private Vector2 posInit; //upperleft corner's position in the matrix
	private Vector2 indexCurrent; //current tile for correction
	private Vector2 coordCurrent; //current tile coord

	public GameObject room;
	public GameObject destroyPart;
	public int memRoom;
	public float timeToChill;

	private float sizeRoom = 10;
	private bool endRage = false;
	private float timeCount;

	void Start () 
	{

		//sizeRoom = (floor.GetComponent(Renderer).bounds.size ;
		posInit = new Vector2 (-(sizeRoom * memRoom), sizeRoom * memRoom);
		// Init matrixEnviron
		for(int i=0; i< memRoom*2 + 1; i++)
		{

			List<GameObject> rowEnviron = new List<GameObject>();

			for(int j=0; j< memRoom*2 + 1; j++)
			{

				if( i == memRoom && j == memRoom )
					rowEnviron.Add( room );
				else
					rowEnviron.Add( (GameObject) Instantiate(room, new Vector3(posInit[0] + sizeRoom*j, 0, posInit[1] - sizeRoom*i), Quaternion.identity) );

				rowEnviron[j].name = "room" + i + j;
			}
			 
			matrixEnviron.Add (rowEnviron);
		}
	}

	void Update()
	{

		timeCount += Time.deltaTime;
		if (timeCount > timeToChill) {
			Application.LoadLevel ("0.3 Negociacion");
		}
	}

	void OnTriggerEnter(Collider other)
	{

//		indexCurrent = new Vector2 ( 	(GetComponent<Transform>().position.x - posInit[0]) / sizeRoom, 
//		                            	(GetComponent<Transform>().position.z - posInit[1]) / sizeRoom		);
	
		if(other.tag == "tileColl")
		{

			coordCurrent = new Vector2 (other.transform.position.x, other.transform.position.z);
			indexCurrent = new Vector2 ((-(posInit[0]-coordCurrent[0]))/sizeRoom, (posInit[1]-coordCurrent[1])/sizeRoom ); // <=========

			//Debug.Log("X: " + indexCurrent[0] + ", Y: " + indexCurrent[1] );

			updateMatrix();

			return;
		}

		if(other.tag == "fallColl")
		{
			Application.LoadLevel ("0.2 Ira");
		}

		if(other.tag != "floor")
		{

			Instantiate(destroyPart, other.transform.position, Quaternion.LookRotation(GetComponent<Rigidbody>().velocity));
			Destroy(other.gameObject);
			timeCount=0;
		}


	}
	
	void updateMatrix()
	{


		Vector2 indexRelCentre = new Vector2(indexCurrent[0]-memRoom,indexCurrent[1]-memRoom);

		//Horizontal
		if( indexRelCentre[0] < 0 ) //Left
		{

			posInit[0] -= sizeRoom;
			for(int i=0; i< memRoom*2 + 1; i++){
 				matrixEnviron[i].Insert(0, (GameObject) Instantiate(room, new Vector3(posInit[0], 0, posInit[1] - sizeRoom*i), Quaternion.identity));
				int last = matrixEnviron[i].Count - 1;
				Destroy(matrixEnviron[i][last]);
				matrixEnviron[i].RemoveAt(last);
			}

		}else
		if( indexRelCentre[0] > 0 ) //Right
		{

			posInit[0] += sizeRoom;

			for(int i=0; i< memRoom*2 + 1; i++){
				int last = matrixEnviron[i].Count - 1;
				matrixEnviron[i].Add( (GameObject) Instantiate(room, new Vector3(posInit[0] + sizeRoom*(last) , 0, posInit[1] - sizeRoom*i), Quaternion.identity));
				Destroy(matrixEnviron[i].First());
				matrixEnviron[i].RemoveAt(0);
			}
		}

		//Vertical
		if( indexRelCentre[1] < 0 ) //Up
		{
			
			posInit[1] += sizeRoom;

			int last = matrixEnviron.Count - 1;
			List<GameObject> rowEnviron = new List<GameObject>();
			for(int i=0; i< memRoom*2 + 1; i++){
				rowEnviron.Add( (GameObject) Instantiate(room, new Vector3(posInit[0]+ sizeRoom*i, 0, posInit[1]), Quaternion.identity));
				Destroy(matrixEnviron[last][i]);
			}
			matrixEnviron.RemoveAt(last);
			matrixEnviron.Insert(0, rowEnviron);

		}else
		if( indexRelCentre[1] > 0 ) //Down
		{
			
			posInit[1] -= sizeRoom;
			
			int last = matrixEnviron.Count - 1;
			List<GameObject> rowEnviron = new List<GameObject>();
			for(int i=0; i< memRoom*2 + 1; i++){
				rowEnviron.Add( (GameObject) Instantiate(room, new Vector3(posInit[0]+ sizeRoom*i, 0, posInit[1] - sizeRoom*last), Quaternion.identity));
				Destroy(matrixEnviron[0][i]);
			}
			matrixEnviron.Insert(last, rowEnviron);
			matrixEnviron.RemoveAt(0);
		}


	}

}
