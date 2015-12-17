using UnityEngine;
using System.Collections;
using UnityEditor;

public class GUIScript : MonoBehaviour {

    
    float windowWidth, windowHeight, RightX, RightY, BottomX, BottomY, scrollright;
    private bool toggle;
    public GUIStyle MySkin;
    bool showWindow = false;
    float News_Window_Height = 100;
    float News_Window_Width = 100;
    GUIStyle ButtonStyle = new GUIStyle(GUI.skin.button);
    // Use this for initialization
    void Start () {
        ButtonStyle.normal.textColor = Color.black;
    }
    public Vector2 scrollviewpos = Vector2.zero;
    public float scrollPos = 0f;
    void OnGUI()
    {

        float theTime = Time.time;
        scrollright = theTime * 5;
        if (scrollright > Screen.width / 2)
        {
            theTime = 0;
        }
        windowWidth = Screen.width;
        windowHeight = Screen.height;
        RightX = Screen.width * 0.25f;
        RightY = Screen.height;
        BottomX = Screen.width - RightX;
        BottomY = Screen.height * 0.07f;
        //GUI.BeginGroup(new Rect(windowWidth - RightX, 0, RightX, RightY));
        //GUI.Box(new Rect(0, 0, RightX, RightY), "Agent Controls", MySkin);
        //scrollPos = GUI.VerticalScrollbar(new Rect(RightX - 16, 0, 10.0f, RightY), scrollPos, 1.0f, 0.0f, 10.0f);
        //GUI.BeginScrollView(new Rect(0, 20, RightX, RightY - 20), scrollviewpos, new Rect(0, 0, RightX * 2, RightY * 2));
        //GUI.EndGroup();
        scrollviewpos = GUI.BeginScrollView(new Rect(windowWidth - RightX, 0, RightX, RightY), scrollviewpos, new Rect(0, 0, 220, 200));
        GUI.Box(new Rect(0, 0, RightX + scrollviewpos.x, RightY + scrollviewpos.y), "Agent Controls", MySkin);
        GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
        GUI.EndScrollView();
        GUI.BeginGroup(new Rect(0, windowHeight - BottomY, BottomX, BottomY));
        GUI.Box(new Rect(0, 0, BottomX, BottomY),"", MySkin);
        //new Rect(scrollright, 5, 50, 50)
        GUILayout.BeginArea(new Rect(scrollright, 5, BottomX, BottomY));
        if (GUILayout.Button( "Testausta12", MySkin))
            showWindow = true;
        GUILayout.EndArea();
        GUI.EndGroup();
        if (showWindow)
        {
            GUI.Window(0, new Rect(10, 10, News_Window_Width, News_Window_Height), News_window, "News");
        }
        
        
    }

    void News_window(int windowID)
    {
        showWindow = !GUI.Button(new Rect(News_Window_Width-15, 0, 15, 15), "X");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
