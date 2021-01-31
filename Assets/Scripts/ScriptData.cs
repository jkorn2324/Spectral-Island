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
        npcTextMap.Add(1, new string[] { "To think that you, of all people, would turn on me.",
                                        "I thought we were friends." });

        playerResponseMap.Add(11, "… We were.");
        npcTextMap.Add(11, new string[] { "Then tell me why you turned on me." });

        playerResponseMap.Add(111, "I looked up to you, but it wasn’t so simple.");
        npcTextMap.Add(111, new string[] { "You always praised me and told me how perfect I was.",
                                            "But you were amazing too." });

        playerResponseMap.Add(1111, "Can we start over?");
        npcTextMap.Add(1111, new string[] { "I can’t quite forgive you yet.",
                                            "But I am willing to start over so long as we don’t keep our feelings secret anymore.",
                                            "You revived this Soul!" });

        playerResponseMap.Add(1112, "I couldn’t stand you because you were so perfect.");
        npcTextMap.Add(1112, new string[] { "I may have been perfect in your eyes.",
                                            "But I didn’t quite think so highly of myself.",
                                            "It makes your betraying me more ironic, doesn’t it?",
                                            "The Soul fades away." });

        playerResponseMap.Add(112, "You could do everything that I couldn’t.");
        npcTextMap.Add(112, new string[] { "So it was a case of being petty and envious.",
                                           "I can’t change your feelings, but you didn’t have to hurt me." });

        playerResponseMap.Add(1121, "I guess that is true.");
        npcTextMap.Add(1121, new string[] { "Well, I can’t expect we can go back to the way we were.",
                                            "But as long as you realize that betraying me was not right, that will be enough.",
                                            "The Soul fades away." });

        playerResponseMap.Add(1122, "It hurt being able to only do half of what you did.");
        npcTextMap.Add(1122, new string[] { "Then you shouldn’t let yourself be so trapped in my shadow!",
                                            "You should become your own person as long as that doesn’t involve hurting others.",
                                            "The Soul fades away." });

        playerResponseMap.Add(12, "But you were so much better than me.");
        npcTextMap.Add(12, new string[] { "That’s not how I saw it." });

        playerResponseMap.Add(121, "Then tell me how you felt.");
        npcTextMap.Add(121, new string[] { "I had impressive abilities, but I didn’t feel pride because I was still trying to learn how to love myself.",
                                           "And if anything, I looked up to you." });

        playerResponseMap.Add(1211, "It seems we both misunderstood each other.");
        npcTextMap.Add(1211, new string[] { "It certainly seems so.",
                                            "Well, things won’t be the same between us, but we can try starting over and talking about our feelings, both good and bad.",
                                            "You revived this Soul!" });

        playerResponseMap.Add(1212, "I can’t believe it.");
        npcTextMap.Add(1212, new string[] { "Is it really so unbelievable?",
                                            "Not everyone who’s successful is completely happy with themselves.",
                                            "Things are never as black and white as you’d like to believe.",
                                            "The Soul fades away." });

        playerResponseMap.Add(122, "How was it to you then?!");
        npcTextMap.Add(122, new string[] { "I was unhappy.",
                                           "Leading a “successful” life doesn’t mean I was entirely happy with myself." });

        playerResponseMap.Add(1221, "Then how did that feel?");
        npcTextMap.Add(1221, new string[] { "I felt suffocated by expectations.",
                                            "I thought you were different and accepted me, warts and all.",
                                            "So it hurt when I realized you only saw me as someone to envy.",
                                            "The Soul fades away." });

        playerResponseMap.Add(1222, "But how could you have been unhappy?");
        npcTextMap.Add(1222, new string[] { "I felt suffocated by expectations.",
                                            "I thought you were different and accepted me, warts and all.",
                                            "But it seems you only saw me for my societal merit.",
                                            "The Soul fades away." });

        
        // boss 2: drowned
        npcTextMap.Add(2, new string[] { "I can’t believe it… You really came back for me."});

        playerResponseMap.Add(21, "What do you mean?");
        npcTextMap.Add(21, new string[] { "Ah, of course you wouldn’t remember.",
                                          "You didn’t spare me a second glance, when I desperately needed help." });

        playerResponseMap.Add(211, "I wanted to help, but I didn’t know how!");
        npcTextMap.Add(211, new string[] { "But when you helped, it made me feel better even a little.",
                                           "So when you left me behind… I felt so alone and helpless." });

        playerResponseMap.Add(2111, "I’m sorry. I’ll be there for you next time.");
        npcTextMap.Add(2111, new string[] { "… It’s okay. I know you didn’t always know what to do.",
                                            "Next time, let’s be there for each other.",
                                            "You revived this Soul!" });

        playerResponseMap.Add(2112, "It still seems like what I did wasn’t enough for you.");
        npcTextMap.Add(2112, new string[] { "Didn’t I already say your support was enough?!",
                                            "I didn’t ask you to carry my burdens for me.",
                                            "Friends should be able to support each other.",
                                            "The Soul fades away." });

        playerResponseMap.Add(212, "There was only so much I could do.");
        npcTextMap.Add(212, new string[] { "I didn’t need you to solve my problems for me!",
                                           "I trusted you and I just needed some support." });

        playerResponseMap.Add(2121, "Is there a way I can help you now?");
        npcTextMap.Add(2121, new string[] { "It’s too late for me now.",
                                            "But maybe there will be someone in the future who will need you.",
                                            "I only hope you don’t abandon them like you did me.",
                                            "The Soul fades away." });

        playerResponseMap.Add(2122, "I don’t think we can continue like this.");
        npcTextMap.Add(2122, new string[] { "That’s funny coming from you.",
                                            "Well, whenever you find yourself in need of support, don’t be surprised when no one comes to your aid.",
                                            "The Soul fades away." });

        playerResponseMap.Add(22, "I couldn’t just leave you.");
        npcTextMap.Add(22, new string[] { "Are you so sure?",
                                          "You seemed eager to leave me behind when I needed you most.",
                                          "And now you come back long after the damage has been done." });

        playerResponseMap.Add(221, "I’m sorry. Can you tell me what happened?");
        npcTextMap.Add(221, new string[] { "I just sunk further and further into a dark place.",
                                           "I tried to take care of my problems on my own, but I just needed a little extra support." });

        playerResponseMap.Add(2211, "Will you allow me to try again?");
        npcTextMap.Add(2211, new string[] { "I still feel angry with you.",
                                            "But I understand you didn’t abandon me out of malice. ",
                                            "We can try again as friends, with all the good and bad that comes with it.",
                                            "You revived this Soul!" });

        playerResponseMap.Add(2212, "You should’ve tried harder on your own.");
        npcTextMap.Add(2212, new string[] { "Don’t you think I’m fully aware that my problems are my own responsibility?",
                                            "I never asked you to shoulder my burden for me, just to stay by my side as I weathered the storm.",
                                            "The Soul fades away." });

        playerResponseMap.Add(222, "What happened to you wasn’t my fault.");
        npcTextMap.Add(222, new string[] { "I’m not blaming you for what happened.",
                                           "But you could’ve done more than just leave me without a word.",
                                           "You did your best to help me.",
                                           "But I wish you could’ve done a little more.",
                                           "Even if that meant just staying with me until my crisis passed." });

        playerResponseMap.Add(2221, "Please tell me what I should do.");
        npcTextMap.Add(2221, new string[] { "I wish you talked to me properly.",
                                            "It’s too late now, but I advise that you be honest with those you care about.",
                                            "Talk to them and learn what they need.",
                                            "More often than not, they don’t need a savior.",
                                            "They just need someone who will stand by them and be a shoulder to lean on when life becomes rough.",
                                            "The Soul fades away." });

        playerResponseMap.Add(2222, "You still sound like you’re blaming me.");
        npcTextMap.Add(2222, new string[] { "It is hard not to feel angry with you",
                                            "If you’d just told me I was such a burden to you, then maybe things could have turned out differently.",
                                            "All I wanted was someone to be supportive while I weathered a crisis.",
                                            "But it’s too bad that you didn’t seem to care.",
                                            "Even a little bit.",
                                            "The Soul fades away." });


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
