using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NegotiationPlayer : MonoBehaviour {


    public GameObject panelA;
    public GameObject panelB;
    public GameObject panelC;
    public GameObject panelC1;
    public GameObject panelC2;
    public GameObject panelC3;
    public GameObject panelD;
    public GameObject panelE;

    private bool _isDialogOn = false;

	// Use this for initialization
	void Start () {
        panelA.SetActive(false);
        panelB.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
              initDialog();

    }

    void initDialog()
    {
        if (!_isDialogOn)
        {
            _isDialogOn = true;
            print("Hola!");
            panelA.SetActive(true);
        }
    }

    public void toStateA()
    {
        panelB.SetActive(false);
        panelA.SetActive(true);
    }

    public void toStateB()
    {
        panelA.SetActive(true);
        panelB.SetActive(false);
    }

}
