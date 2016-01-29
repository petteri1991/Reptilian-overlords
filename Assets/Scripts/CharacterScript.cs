using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;
    private bool interact = false, lastinteract = false;
    string InteractObject = "";
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
                if (hit.transform.tag == "Interactable")
                {
                    interact = true;
                    InteractObject = hit.transform.name;
                }
                else
                {
                    InteractObject = "";
                    interact = false;
                }
            }
            
        }
        animator.SetFloat("MoveVertical", agent.velocity.sqrMagnitude);
        if (interact)
        {
            if (InteractObject != "")
            {
                if (lastinteract)
                {
                    GameObject.Find(InteractObject).GetComponent<AudioSource>().Stop();
                    lastinteract = false;
                }

                if (agent.velocity.magnitude < 0.1f && agent.velocity.magnitude > -0.1f)
                {
                    GameObject.Find(InteractObject).GetComponent<AudioSource>().Play();
                    lastinteract = true;
                }

            }
        }
    }
}
