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
        if (Manager.GameMode == GlobalGameStateManager.gameMode.overworld)
        {
            if (GUI.Button(new Rect(10, 90, 200, 50), "Overworld Dialogue Test", style))
            {
                FindObjectOfType<OverworldTypewriter>().SetText("test");
            }
        }
        if (Manager.GameMode == GlobalGameStateManager.gameMode.battle)
        {
            if (GUI.Button(new Rect(10, 90, 200, 50), "Set Boss to Stabbed", style))
            {
                Manager.ActivateBoss(1);
            }
            if (GUI.Button(new Rect(10, 150, 200, 50), "Set Boss to Drowned", style))
            {
                Manager.ActivateBoss(2);
            }
            if (GUI.Button(new Rect(10, 210, 200, 50), "Set Boss to Strangled", style))
            {
                Manager.ActivateBoss(3);
            }
            if (GUI.Button(new Rect(10, 270, 200, 50), "Set Boss to Burned", style))
            {
                Manager.ActivateBoss(4);
            }
            if (GUI.Button(new Rect(10, 330, 200, 50), "Set Boss to Final", style))
            {
                Manager.ActivateBoss(5);
            }
        }
        //GUI.Label(new Rect(10, 70, 100, 50), $"More info about the player can be added here", style);
    }

}
