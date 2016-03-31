using UnityEngine;
using SimpleJSON;
using System;
using System.IO;
using System.Collections;

public class JSON_Test : MonoBehaviour {

    // Use this for initialization
    string Atlas;
    string objectInfo;
    public GameObject cube;
    public GameObject room;
    void Start () {
        Atlas = System.IO.File.ReadAllText(Application.dataPath +"/JSON/Atlas/hallway/hallwayAtlas.json");
        objectInfo = System.IO.File.ReadAllText(Application.dataPath + "/JSON/Position/rooms.json");
        
        var JSONAtlas = JSON.Parse(Atlas);
        var JSONobjectInfo = JSON.Parse(objectInfo);
        
        var frames = JSONAtlas["frames"];
        int positionx = 0;
        int positiony = 0;
        int height = 0;
        int width = 0;

        float targety = 720;
        float targetx = 2048;
        float currentSizex = room.GetComponent<Renderer>().bounds.size.x;
        float currentSizey = room.GetComponent<Renderer>().bounds.size.x;

        Vector3 scale = room.transform.localScale;

        scale.x = targetx * scale.x / currentSizex;
        scale.y = targety * scale.y / currentSizey;

        room.transform.localScale = scale;
        int count = frames.Count;
        for (int x = 0; x <= count ;x++)
        {
            positionx = frames[x]["frame"]["x"].AsInt;
            positiony = frames[x]["frame"]["y"].AsInt;
            height = frames[x]["frame"]["h"].AsInt;
            width = frames[x]["frame"]["w"].AsInt;
            GameObject objectjson = Instantiate(cube, new Vector3(positionx, positiony,-1), Quaternion.identity) as GameObject;
            objectjson.name = frames[x]["filename"].Value;
            currentSizex = objectjson.GetComponent<Renderer>().bounds.size.x;
            currentSizey = objectjson.GetComponent<Renderer>().bounds.size.x;

            scale = objectjson.transform.localScale;

            scale.x = width * scale.x / currentSizex;
            scale.y = height * scale.y / currentSizey;

            objectjson.transform.localScale = scale;
        }
    }
    
    // Update is called once per frame
    void Update () {
	
	}
}
