using UnityEngine;
using System.Collections;
using UnityEditor;
using System;


public class GUIScript : MonoBehaviour {

    Configure config = new Configure();
    float windowWidth, windowHeight, RightX, RightY, BottomX, BottomY, BottomHeight, BottomWidth, scrollright, RightWidth, RightHeight;
    public GUIStyle MySkin;
    public GUIStyle NewsSkin;
    bool showWindow = false;
    float News_Window_Height = 200;
    float News_Window_Width = 200;
    string subject,content;
    bool ShowCompanyDetails = false;
    bool ShowAgentDetails = true;
    // Use this for initialization
    void Start () {
    
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
        windowWidth = config.WindowWidth;
        windowHeight = config.WindowHeight;
        RightWidth = 200;
        RightHeight = windowHeight;
        RightX = windowWidth - RightWidth;
        RightY = 0;
        BottomX = 0;
        BottomHeight = windowHeight * 0.07f;
        BottomWidth = windowWidth - RightWidth;
        BottomY = windowHeight-BottomHeight;
        //scaling news font to keep it inside news box
        MySkin.fontSize = (int)Math.Floor(BottomHeight) - 10;

        GUI.BeginGroup(new Rect(RightX, RightY, RightWidth, RightHeight));
            GUI.Box(new Rect(0, 0, RightWidth, RightHeight + scrollviewpos.y), "", MySkin);
            if(GUI.Button(new Rect(15, 5, 76, 23), "Agents"))
            {
                ShowCompanyDetails = false;
                ShowAgentDetails = true;
            }
            if(GUI.Button(new Rect(100, 5, 76, 23), "Company"))
            { 
                ShowCompanyDetails = true;
                ShowAgentDetails = false;
            }
            scrollviewpos = GUI.BeginScrollView(new Rect(5, 40, RightWidth, RightHeight-40), scrollviewpos, new Rect(0, 0, RightWidth-17, 400));
                GUI.Box(new Rect(0, 0, RightWidth, RightHeight - 40), "", MySkin);
                GUILayout.BeginVertical();
                    if (GUILayout.Button("Testausta12"))
                    {
                    
                    }

                    if (GUILayout.Button("Testausta13"))
                    {

                    }
                    if (GUILayout.Button("Testausta14"))
                    {
                            
                    }
                GUILayout.EndVertical();
            GUI.EndScrollView();
        GUI.EndGroup();
        //News Panel
        GUI.BeginGroup(new Rect(BottomX, BottomY, BottomWidth, BottomHeight), MySkin);
            GUI.Box(new Rect(0, 0, BottomX, BottomY), "", MySkin);
            GUILayout.BeginArea(new Rect(scrollright, 5, BottomWidth, BottomHeight));
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Testausta12",MySkin))
                {
                    ButtonClicked("Test12","Tässä on uutisen teksti jeee jee jee");
                    showWindow = true;
                }
        
                if (GUILayout.Button("Testausta13", MySkin))
                {
                    ButtonClicked("Testausta13", "Tässä on uutisen teksti jeee jee jee");
                    showWindow = true;
                }
                if (GUILayout.Button("Testausta14", MySkin))
                {
                    ButtonClicked("Testaus14", "Tässä on uutisen teksti jeee jee jee");
                    showWindow = true;
                }
                GUILayout.EndHorizontal();
            GUILayout.EndArea();
        GUI.EndGroup();

        if (showWindow)
        {
            GUI.Window(0, new Rect(10, 10, News_Window_Width, News_Window_Height), News_window, "News");
        }
    }
    void ButtonClicked(string Subject, string Content)
    {
        subject = Subject;
        content = Content;
    }
    void News_window(int windowID)
    {
        showWindow = !GUI.Button(new Rect(News_Window_Width-15, 0, 15, 15), "X");
        GUILayout.Label(subject, NewsSkin);
        GUILayout.Label(content);
    }
}
