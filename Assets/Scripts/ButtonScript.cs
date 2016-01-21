using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
    public GameObject AgentPanel;
    public GameObject CompanyPanel;

    public void Button_Clicked()
    {
        if(this.gameObject.name == "Company_Button")
        {
            AgentPanel.SetActive(false);
            CompanyPanel.SetActive(true);
        }
        if(this.gameObject.name == "Agent_Button")
        {
            CompanyPanel.SetActive(false);
            AgentPanel.SetActive(true);
        }
    }
}
