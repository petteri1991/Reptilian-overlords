using UnityEngine;
using System.Collections;

public class Rigidbody_Controls : MonoBehaviour {

    public float speed;
    public float tilt;
    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveVertical, 0.0f, 0.0f);
        //rigidbody.velocity = movement * speed;

        //rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
        rigidbody.MovePosition(rigidbody.position + movement * Time.deltaTime);

    }
}