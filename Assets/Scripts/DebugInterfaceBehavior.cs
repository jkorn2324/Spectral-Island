using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInterfaceBehavior : MonoBehaviour
{
    private GUIStyle style = new GUIStyle();

    // game references
    public GlobalGameStateManager Manager;
    public GameObject Player;
    public BossController Boss;

    void Start()
    {
        Manager = FindObjectOfType<GlobalGameStateManager>();
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
        if (GUI.Button(new Rect(10, 30, 250, 50), $"Game Mode: {Manager.GameMode}", style))
        {
            Manager.GameMode += 1;
            if (Manager.GameMode == GlobalGameStateManager.gameMode.count)
            {
                Manager.GameMode = (GlobalGameStateManager.gameMode)0;
            }
        }
        if (Manager.GameMode == GlobalGameStateManager.gameMode.battle)
        {
            if (GUI.Button(new Rect(10, 90, 200, 50), "Increase Boss HP", style))
            {
                Boss.ChangeHp(.5f);
            }
            if (GUI.Button(new Rect(10, 150, 200, 50), "Decrease Boss HP", style))
            {
                Boss.ChangeHp(-.5f);
            }
        }
        //GUI.Label(new Rect(10, 70, 100, 50), $"More info about the player can be added here", style);
    }

}
