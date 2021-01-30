using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUIController : MonoBehaviour
{
    public GlobalGameStateManager Manager;
    public CanvasGroup CanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<GlobalGameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // todo: pull this out into the mode swap function when we implment it, because setting this every frame is dumb
        if (Manager.GameMode == GlobalGameStateManager.gameMode.battle)
        {
            CanvasGroup.alpha = 1f;
        }
        else
        {
            CanvasGroup.alpha = 0f;
        }
        
    }
}
