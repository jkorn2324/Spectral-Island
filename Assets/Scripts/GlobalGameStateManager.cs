using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameStateManager : MonoBehaviour
{
    public enum gameMode
    {
        menu, // currently unused (probably start menu or something)
        overworld,
        battle,
        count // just used to keep track of the number of modes
    }
    public gameMode GameMode = gameMode.overworld; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
