using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameStateManager : MonoBehaviour
{
    // items
    public const int axe = 1;
    public const int vest = 2;
    public const int rope = 3;
    public const int torch = 4;
    // inventory
    public bool[] Inventory = new bool[4];
    public bool[] BossStatus = new bool[4];

    public bool HasItem(int item)
    {
        return Inventory[item - 1];
    }

    public void GiveItem(int item)
    {
        Inventory[item - 1] = true;
        // do special tilemap stuff here
    }

    public bool WonBoss(int key)
    {
        return BossStatus[key - 1];
    }

    public void SetBossWon(int key)
    {
        BossStatus[key - 1] = true;
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
