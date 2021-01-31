using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GlobalGameStateManager : MonoBehaviour
{
    public GameObject[] BossSprites;
    public TilemapCollider2D SwimmableWater;
    public bool ControlsLocked = false;
    // bosses
    public GameObject[] BossReferences;
    // items
    public const int axe = 1;
    public const int vest = 2;
    public const int rope = 3;
    public const int torch = 4;
    // inventory
    public bool[] Inventory = new bool[5];
    public bool[] BossWonStatus = new bool[5];
    public bool[] BossSeenStatus = new bool[5];

    public bool HasItem(int item)
    {
        return Inventory[item - 1];
    }

    public void GiveItem(int item)
    {
        Inventory[item - 1] = true;

        if (item == 1)
        {
            FindObjectOfType<OverworldTypewriter>().SetText("gotaxe");
        }
        if (item == 2)
        {
            FindObjectOfType<OverworldTypewriter>().SetText("gotvest");
        }
        if (item == 3)
        {
            FindObjectOfType<OverworldTypewriter>().SetText("gotrope");
        }
        if (item == 4)
        {
            FindObjectOfType<OverworldTypewriter>().SetText("gottorch");
        }
        if (item == 5)
        {
            FindObjectOfType<OverworldTypewriter>().SetText("gotend");
        }
    }

    public void ActivateBoss(int key)
    {
        GameMode = gameMode.battle;
        for (int i = 0; i < 5; i++)
        {
            BossReferences[i].SetActive(false);
        }
        BossReferences[key - 1].SetActive(true);
        FindObjectOfType<TypeWriter>().SetBoss(key);
        FindObjectOfType<ChoiceWriter>().SetBoss(key);
        FindObjectOfType<TypeWriter>().SetText(key);
    }

    public bool SawBoss(int key)
    {
        return BossSeenStatus[key - 1];
    }

    public void SetBossSeen(int key)
    {
        BossSeenStatus[key - 1] = true;
    }

    public bool WonBoss(int key)
    {
        return BossWonStatus[key - 1];
    }

    public void SetBossWon(int key)
    {
        BossWonStatus[key - 1] = true;
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
