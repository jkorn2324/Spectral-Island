using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameStateManager : MonoBehaviour
{
    // items
    public const int axe = 1;
    public const int torch = 2;
    public const int rope = 3;
    public const int vest = 4;
    // inventory
    public bool[] inventory = new bool[4];

    public bool HasItem(int item)
    {
        return inventory[item];
    }

    public void GiveItem(int item)
    {
        inventory[item] = true;
    }

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
