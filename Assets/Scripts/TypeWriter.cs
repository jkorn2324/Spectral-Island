using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public Text textBox;
    public BossController Boss; // this needs to be set each time by the Boss when it initializes
    string[] textList;
    public ScriptData Script;
    int currentTextIndex = -1;
    public float typewriterDelay = 0.05f;
    private IEnumerator currentCoroutine;
    private bool coroutineLock;
    private bool shouldWrite;
    private bool skipRequested = false;


    void Awake()
    {
        textList = new string[] { };
        InitTypewriter(false);
        Script = FindObjectOfType<ScriptData>();
    }

    public void SetText(int boss, int phase, int posorneg)
    {
        InitTypewriter(true);
        textList = Script.npcTextArray[boss][phase][posorneg];
    }

    public void AdvanceText()
    {
        currentTextIndex++;
        if (currentTextIndex >= textList.Length)
        {
            InitTypewriter(false);
            Boss.scriptSeen = true;
        }
        else
        {
            // todo: make textbox start sound
            StartCoroutine(WriteText());
        }
    }

    public void InitTypewriter(bool shouldWrite)
    {
        textBox.text = "";
        this.shouldWrite = shouldWrite;
        currentTextIndex = -1;
    }

    IEnumerator WriteText()
    {
        coroutineLock = true;
        for (int i = 0; i < (textList[currentTextIndex].Length + 1); i++)
        {
            if (skipRequested)
            {
                textBox.text = textList[currentTextIndex];
                skipRequested = false;
                break;
            }
            textBox.text = textList[currentTextIndex].Substring(0, i);
            // todo: make typing sound
            yield return new WaitForSeconds(typewriterDelay);
        }
        coroutineLock = false;
    }

    public void Update()
    {
        if (shouldWrite)
        {
            if (currentTextIndex == -1)
            {
                AdvanceText();
            }
            if (!coroutineLock)
            {
                if (Input.GetButtonDown("Interact")) // player continues
                {
                    UnityEngine.Debug.Log("Advance Text");
                    AdvanceText();
                }
            }
            else if (Input.GetButtonDown("Interact")) // player skip
            {
                UnityEngine.Debug.Log("Text Skip Requested");
                skipRequested = true;
            }
        }
    }
}
