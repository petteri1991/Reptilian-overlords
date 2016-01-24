using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    private Animator animat;
    private NavMeshAgent agent;

    float MoveVertical, MoveHorizontal;
    private float last_velocity;
    private string destination_building_tag;
    private string destination_building_name;
    
    float rotationspeed = 100;
    public GameObject DestinationBuilding { get; private set; }
    bool Interact = false;
    bool Run = false;
    GameObject office;
    // Use this for initialization
    void Start () {
        animat = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        office = GameObject.Find("officemod2");
        //agent.transform.position.Set(agent.transform.position.x,0,agent.transform.position.z);
    }
    public float speed = 0.02f;
    float MoveX = 0;
    float MoveY = 0;
    void Update () {
        /*
        MoveVertical = Input.GetAxis("Vertical");
        MoveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.E))
            Interact = true;
        else
            Interact = false;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Run = true;
        if(Input.GetKeyUp(KeyCode.LeftShift))
            Run = false;
        animat.SetFloat("MoveVertical", MoveVertical);
        animat.SetBool("Run", Run);
        agent.transform.Rotate(0, MoveHorizontal * 1.8f, 0, Space.World);
        */
        animat.SetBool("Interact", Interact);
        animat.SetFloat("MoveVertical", MoveVertical);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                //agent.destination = hit.point;
                destination_building_tag = hit.transform.tag;
                destination_building_name = hit.transform.name;
                DestinationBuilding = GameObject.Find(destination_building_name);
            }
        }
        if (agent.velocity.magnitude > 0.3f)
        {
            agent.updateRotation = true;
            last_velocity = agent.velocity.magnitude;
            Interact = false;
        }
        if (agent.velocity.magnitude < 1.5f && last_velocity > 0.0f)
        {
            if (destination_building_tag == "Interactable")
            {
                agent.updateRotation = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && agent.velocity.magnitude < 0.2f)
        {
            Interact = true;
        }
        MoveVertical = agent.velocity.magnitude;
    }
}
