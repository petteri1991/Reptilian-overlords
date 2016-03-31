using UnityEngine;
using System.Collections;

public class Hearing : MonoBehaviour {

    // Use this for initialization
    NavMeshAgent agent;
    public GameObject worker;
    void Start () {
        agent = worker.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    Vector3 soundrange;
	void Update () {
        soundrange = new Vector3(this.transform.position.x + this.GetComponent<AudioSource>().maxDistance + 1, this.transform.position.y, this.transform.position.z + GetComponent<AudioSource>().maxDistance + 1);
        if ( this.GetComponent<AudioSource>().isPlaying && (worker.transform.position.x-soundrange.x <= 0.0f && worker.transform.position.z - soundrange.z <= 0.0f))
        {
            Debug.Log("hearing");
            agent.SetDestination(this.transform.position);
        }
	}

}
