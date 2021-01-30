using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInterfaceBehavior : MonoBehaviour
{
    private GUIStyle style = new GUIStyle();

    // game references
    public GameObject Player;

    void Start()
    {
        style.fontSize = 30;
    }

    void Update()
    {
    }

    void OnGUI()
    {
        //if (GUI.Button(new Rect(10, 10, 150, 50), "Debug Button Example"))
        //{
        //    print("Button pressed");
        //}
        GUI.Label(new Rect(10, 10, 100, 50), $"Player position ({Player.transform.position.x} : {Player.transform.position.y})", style);
        GUI.Label(new Rect(10, 70, 100, 50), $"More info about the player can be added here", style);
    }

}
