using UnityEngine;
using System.Collections;
using System.Linq;

public class AgentScript : MonoBehaviour {

    private NavMeshAgent agent;
    float last_velocity = 0.0f;
    public GameObject Player;
    public GameObject Path;
    GameObject DestinationBuilding;
    int in_Player_company_agents = 0;
    int in_Enemy_company_agents = 0;
    string destination_building_tag = "";
    string destination_building_name = "";
    string last_building_name = "";
    TextMesh last_building_text;
    TextMesh new_building_text;
    // Use this for initialization
    void Start () {

        agent = GetComponent<NavMeshAgent>();

	}

    // Update is called once per frame
    void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Player.GetComponent<Renderer>().enabled = true;

            if (Physics.Raycast(ray,out hit)) 
            {
                last_building_name = destination_building_name;
                last_building_text = new_building_text;
                destination_building_name = hit.transform.name;
                DestinationBuilding = GameObject.Find(destination_building_name);
                new_building_text = DestinationBuilding.GetComponentInChildren<TextMesh>();
                destination_building_tag = hit.transform.tag;
                agent.destination = DestinationBuilding.transform.position;

            }
        }
        
        if(agent.velocity.magnitude > 0.0f)
        {
            last_velocity = agent.velocity.magnitude;
        }
        if(agent.velocity.magnitude == 0.0f && last_velocity > 0.0f)
        {
            last_velocity = 0.0f;
            if (destination_building_tag == "Corporation")
                Player.GetComponent<Renderer>().enabled = false;
            if (destination_building_name == "Player Company")
            {
                in_Player_company_agents++;
                new_building_text.text = in_Player_company_agents + " Player agents";
                if(last_building_name == "Enemy Company")
                {
                    in_Enemy_company_agents--;
                    last_building_text.text = in_Enemy_company_agents + " Player agents";
                }
            }
            else if(destination_building_name == "Enemy Company")
            {
                in_Enemy_company_agents++;
                new_building_text.text = in_Enemy_company_agents + " Player agents";

                if (last_building_name == "Player Company")
                {
                    in_Player_company_agents--;
                    last_building_text.text = in_Player_company_agents + " Player agents";
                }
            }
            else{ }
        }
    }
}
