using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InteraccionNeg : MonoBehaviour {

    public Transform camTransform;
    private RaycastHit hit = new RaycastHit();
    public GameObject labelNeg;
    public float timeWait = 1.0f;

	// Use this for initialization
	void Start () {
        labelNeg.SetActive(false);
	}


	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.F) || Input.GetMouseButton(0))
            lanzarRaycast();
	}

    void lanzarRaycast()
    {
        Vector3 vDireccion = camTransform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(camTransform.position,vDireccion,out hit,5.0f))
        {
            if(hit.collider.CompareTag("InteraccionNeg"))
            {
                interaccionNo();
            }
        }
    }

    void interaccionNo()
    {
        labelNeg.SetActive(true);
        StartCoroutine("desactivarTexto");
    }

    IEnumerator desactivarTexto()
    {
        yield return new WaitForSeconds(timeWait);
        labelNeg.SetActive(false);
        Text texto = labelNeg.GetComponent<Text>();
        texto.fontSize += 1;
        if (texto.fontSize >= 25)
            texto.fontSize = 15;
        Debug.Log(texto.fontSize);
    }
}
