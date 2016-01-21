using UnityEngine;
using UnityEngine.UI;

public class MyDropdown : MonoBehaviour {

    private int AgentNumber = 0;
    void Start()
    {
    }
    void Destroy()
    {
    
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        Debug.Log("selected: " + target.value);
    }


    public int GetAgentNumber()
    {
        return AgentNumber;
    }
}
