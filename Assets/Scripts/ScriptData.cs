using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptData : MonoBehaviour
{
    //const int numBosses = 4;
    // first index is boss number
    //const int drowned = 1;
    //const int stabbed = 2;
    //// second index is phase
    //const int entry = 0;
    //const int first = 1;
    //const int second = 2;
    //const int third = 3;
    //const int final = 4;
    //// third index is pos/neg
    //const int neu = 0;
    //const int pos = 0;
    //const int neg = 1;
    //// fourth index is actual string
    //public string[][][][] npcTextArray = new string[numBosses][][][];
    //// similar with responses, but there is no fourth index
    //public string[][][] playerResponseArray = new string[numBosses][][];

    public Dictionary<int, string[]> npcTextMap = new Dictionary<int, string[]>();
    public Dictionary<int, string> playerResponseMap = new Dictionary<int, string>();

    public Dictionary<string, string[]> overworldTextMap = new Dictionary<string, string[]>();

    void Start()
    {
        // boss 1: backstab
        npcTextMap.Add(1, new string[] { "To think that you, of all people, would turn on me. I thought we were friends." });

        playerResponseMap.Add(11, "… We were.");
        npcTextMap.Add(11, new string[] { "Then tell me why you turned on me." });

        playerResponseMap.Add(111, "I looked up to you, but it wasn’t so simple.");
        npcTextMap.Add(111, new string[] { "You always praised me and told me how perfect I was.", "But you were amazing too." });

        playerResponseMap.Add(1111, "Can we start over?");
        npcTextMap.Add(1111, new string[] { "I can’t quite forgive you yet.", "But I am willing to start over so long as we don’t keep our feelings secret anymore.", "You revived this Soul!" });

        playerResponseMap.Add(1112, "I couldn’t stand you because you were so perfect.");
        npcTextMap.Add(1112, new string[] { "I may have been perfect in your eyes.", "But I didn’t quite think so highly of myself.", "It makes your betraying me more ironic, doesn’t it?", "The Soul fades away" });

        playerResponseMap.Add(112, "You could do everything and I couldn’t.");
        npcTextMap.Add(112, new string[] { });

        playerResponseMap.Add(1121, "");
        npcTextMap.Add(1121, new string[] { });

        playerResponseMap.Add(1122, "");
        npcTextMap.Add(1122, new string[] { });

        playerResponseMap.Add(12, "player response to reach 12");
        npcTextMap.Add(12, new string[] { });

        playerResponseMap.Add(121, "");
        npcTextMap.Add(121, new string[] { });

        playerResponseMap.Add(1211, "");
        npcTextMap.Add(1211, new string[] { });

        playerResponseMap.Add(1212, "");
        npcTextMap.Add(1212, new string[] { });

        playerResponseMap.Add(122, "");
        npcTextMap.Add(122, new string[] { });

        playerResponseMap.Add(1221, "");
        npcTextMap.Add(1221, new string[] { });

        playerResponseMap.Add(1222, "");
        npcTextMap.Add(1222, new string[] { });


        overworldTextMap.Add("test", new string[] { "hello", "goodbye" });

        //// drowned has 5 phases
        //npcTextArray[drowned] = new string[5][][];
        //playerResponseArray[drowned] = new string[5][];
        //// entry phase has 1 option
        //npcTextArray[drowned][entry] = new string[1][];
        //npcTextArray[drowned][entry][neu] = new string[] {"drowned entry text 1", "drowned entry text 2"};
        //playerResponseArray[drowned] = new string[][] { }; // this will always be empty, but leaving here to maintain index uniformity
        //// phases 1-3 have 2 options
        //npcTextArray[drowned][first] = new string[2][];
        //playerResponseArray[drowned][first] = new string[2];
        //npcTextArray[drowned][first][pos] = new string[] {"drowned p1 pos 1", "drowned p1 pos 2"};
        //npcTextArray[drowned][first][neg] = new string[] {"drowned p1 neg 1", "drowned p1 neg 2"};
        //playerResponseArray[drowned][first][pos] = "drowned p1 pos response";
        //playerResponseArray[drowned][first][neg] = "drowned p1 neg response";
        //npcTextArray[drowned][second] = new string[2][];
        //playerResponseArray[drowned][second] = new string[2];
        //npcTextArray[drowned][second][pos] = new string[] {"drowned p2 pos 1", "drowned p2 pos 2"};
        //npcTextArray[drowned][second][neg] = new string[] {"drowned p2 neg 1", "drowned p2 neg 2"};
        //playerResponseArray[drowned][second][pos] = "drowned p2 pos response";
        //playerResponseArray[drowned][second][neg] = "drowned p2 neg response";
        //npcTextArray[drowned][third] = new string[2][];
        //playerResponseArray[drowned][third] = new string[2];
        //npcTextArray[drowned][third][pos] = new string[] {"drowned p3 pos 1", "drowned p3 pos 2"};
        //npcTextArray[drowned][third][neg] = new string[] {"drowned p3 neg 1", "drowned p3 neg 2"};
        //playerResponseArray[drowned][third][pos] = "drowned p3 pos response";
        //playerResponseArray[drowned][third][neg] = "drowned p3 neg response";
        //// final phase has 1 option
        //npcTextArray[drowned][final] = new string[1][];
        //npcTextArray[drowned][final][neu] = new string[] { "drowned final text 1", "drowned final text 2" };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
