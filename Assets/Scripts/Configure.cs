using UnityEngine;
using System.Collections;
using System;

public class Configure : MonoBehaviour {

    private float windowWidth = Screen.width;
    private float windowHeight = Screen.height;
    // Use this for initialization
    void Start () {
    }
	public float WindowWidth
    {
        get
        {
            return windowWidth;
        }
        set
        {
            windowWidth = value;
        }
    }
    public float WindowHeight
    {
        get
        {
            return windowHeight;
        }
        set
        {
            windowHeight = value;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
