using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptData : MonoBehaviour
{
    const int numBosses = 4;
    // first index is boss number
    const int drowned = 0;
    const int stabbed = 1;
    // second index is phase
    const int entry = 0;
    const int first = 1;
    const int second = 2;
    const int third = 3;
    const int final = 4;
    // third index is pos/neg
    const int neu = 0;
    const int pos = 0;
    const int neg = 1;
    // fourth index is actual string
    public string[][][][] npcTextArray = new string[numBosses][][][];

    void Start()
    {
        // drowned has 5 phases
        npcTextArray[drowned] = new string[5][][];
        // entry phase has 1 option
        npcTextArray[drowned][entry] = new string[1][];
        npcTextArray[drowned][entry][neu] = new string[] {"drowned entry text 1", "drowned entry text 2"};
        // phases 1-3 have 2 options
        npcTextArray[drowned][first] = new string[2][];
        npcTextArray[drowned][first][pos] = new string[] {"drowned p1 pos 1", "drowned p1 pos 2"};
        npcTextArray[drowned][first][neg] = new string[] {"drowned p1 neg 1", "drowned p1 neg 2"};
        npcTextArray[drowned][second] = new string[2][];
        npcTextArray[drowned][second][pos] = new string[] {"drowned p2 pos 1", "drowned p2 pos 2"};
        npcTextArray[drowned][second][neg] = new string[] {"drowned p2 neg 1", "drowned p2 neg 2"};
        npcTextArray[drowned][third] = new string[2][];
        npcTextArray[drowned][third][pos] = new string[] {"drowned p3 pos 1", "drowned p3 pos 2"};
        npcTextArray[drowned][third][neg] = new string[] {"drowned p3 neg 1", "drowned p3 neg 2"};
        // final phase has 1 option
        npcTextArray[drowned][final] = new string[1][];
        npcTextArray[drowned][final][neu] = new string[] {"drowned final text 1", "drowned final text 2"};

        // stabbed has 5 phases
        npcTextArray[stabbed] = new string[5][][];
        // entry phase has 1 option
        npcTextArray[stabbed][entry] = new string[1][];
        npcTextArray[stabbed][entry][neu] = new string[] {"stabbed entry text 1", "stabbed entry text 2"};
        // phases 1-3 have 2 options
        npcTextArray[stabbed][first] = new string[2][];
        npcTextArray[stabbed][first][pos] = new string[] {"stabbed p1 pos 1", "stabbed p1 pos 2"};
        npcTextArray[stabbed][first][neg] = new string[] {"stabbed p1 neg 1", "stabbed p1 neg 2"};
        npcTextArray[stabbed][second] = new string[2][];
        npcTextArray[stabbed][second][pos] = new string[] {"stabbed p2 pos 1", "stabbed p2 pos 2"};
        npcTextArray[stabbed][second][neg] = new string[] {"stabbed p2 neg 1", "stabbed p2 neg 2"};
        npcTextArray[stabbed][third] = new string[2][];
        npcTextArray[stabbed][third][pos] = new string[] {"stabbed p3 pos 1", "stabbed p3 pos 2"};
        npcTextArray[stabbed][third][neg] = new string[] {"stabbed p3 neg 1", "stabbed p3 neg 2"};
        // final phase has 1 option
        npcTextArray[stabbed][final] = new string[1][];
        npcTextArray[stabbed][final][neu] = new string[] {"stabbed final text 1", "stabbed final text 2"};

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
