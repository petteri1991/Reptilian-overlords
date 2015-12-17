using UnityEngine;
using System.Collections;

public class Camera_Controls : MonoBehaviour {

    float speed = 0;
    float rotationspeed = 100;
    public float scrollSpeed = 1000f;
    public float cameraDistanceMax = 9000F;
    public float cameraDistanceMin = 500f;
    public float cameraDistance = 500f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Camera MainCamera = Camera.main;
        float MoveX = 0; //speedX * Input.GetAxis("Horizontal");
        float MoveY = 0; //speedY * Input.GetAxis("Vertical");
        Vector3 RotateX = new Vector3();
        
        if (Input.GetKey(KeyCode.D))
        {
            MoveX = speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveY = -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            MoveY = speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotationspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * -rotationspeed * Time.deltaTime);
        }
        cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        speed = cameraDistance*2;
        MainCamera.transform.Rotate(RotateX);
        MainCamera.transform.Translate(MoveX, MoveY,0);
        MainCamera.orthographicSize = cameraDistance;
    }
}
