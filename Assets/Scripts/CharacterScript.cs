using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    float speed = 200.0f;
    bool rotate = false;
    float time = 1.0f;
    // Update is called once per frame
    void Update () {
        float MoveX = 0; //speedX * Input.GetAxis("Horizontal");
        float MoveY = 0; //speedY * Input.GetAxis("Vertical");
        
        if (Input.GetKey(KeyCode.D))
        {
            MoveX = speed * Time.deltaTime;
            rotate = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -speed * Time.deltaTime;
            rotate = true;
        }
        transform.Translate(MoveX, 0, 0);

        
    }
    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
    }
}
