using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
    
    Transform pivot;
    public GameObject player;
    bool exit = false;
    private Vector3 relativePosition;
    Transform edge;

    void Start () {
        pivot = transform.Find("Pivot");
        edge = transform.Find("Edge");
    }

    void OnCollisionStay(Collision collision)
    {
        if (name == "door_mobile_left")
        {
            //if front and left or back and left
            if (player.transform.position.x - transform.position.x + 10.0f > 0.0f)
            {
                Debug.Log("door_mobile_left FRONT");
                transform.RotateAround(pivot.position, Vector3.up, -20);
            }
            else
            {
                Debug.Log("door_mobile_left BACK");
                transform.RotateAround(pivot.position, Vector3.up, 20);
            }
        }
            
        if (name == "door_mobile_right")
        {
            if (player.transform.position.x - transform.parent.position.x - 10.0f > 0.0f)
            {
                Debug.Log("door_mobile_right FRONT");
                transform.RotateAround(pivot.position, Vector3.up, 20);
            }
            else
            {
                Debug.Log("door_mobile_right BACK");
                transform.RotateAround(pivot.position, Vector3.up, -20);
            }
            
        }
            
    }
    void OnCollisionExit(Collision collision)
    {
        exit = true;
    }
    void FixedUpdate()
    {
            if (exit && player.transform.position.x < transform.parent.position.x + 10)
            {
                if (transform.rotation.eulerAngles.y < 180.0f && name == "door_mobile_left")
                        transform.RotateAround(pivot.position, Vector3.up, 20);
                else if (transform.rotation.eulerAngles.y > 0.0f && name == "door_mobile_right")
                    transform.RotateAround(pivot.position, Vector3.up, -20);
                else
                    exit = false;
            }
    }
}
