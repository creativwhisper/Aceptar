using UnityEngine;
using System.Collections;

public class NegotiationActivator : MonoBehaviour {

    public GameObject panelA;
    public GameObject panelB;
    public GameObject panelC;
    public GameObject panelC1;
    public GameObject panelC2;
    public GameObject panelC3;
    public GameObject panelD;
    public GameObject panelE;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toStateA()
    {
        panelB.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);
        panelA.SetActive(true);
    }

    public void toStateB()
    {
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelB.SetActive(true);
        panelA.SetActive(false);
        panelE.SetActive(false);
    }

    public void toStateC()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(true);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);
    }

    public void toStateC1()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(true);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);
    }

    public void toStateC2()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(true);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);
    }

    public void toStateC3()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(true);
        panelD.SetActive(false);
        panelE.SetActive(false);
    }

    public void toStateD()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(true);
        panelE.SetActive(false);
    }

    public void toStateE()
    {
        panelB.SetActive(false);
        panelA.SetActive(false);
        panelC.SetActive(false);
        panelC1.SetActive(false);
        panelC2.SetActive(false);
        panelC3.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(true);
    }

	public void toInicio()
	{
		Application.LoadLevel ("0.1 Negacion");
	}

	public void toNextLevel()
	{
		Application.LoadLevel ("0.4 Depresion");
	}


}
