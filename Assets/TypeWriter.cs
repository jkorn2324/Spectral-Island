using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public Text textBox;
    string[] textList = new string[] { "sample text 1", "sample text 2", "sample text 3" };
    int currentTextIndex = -1;
    public float typewriterDelay = 0.05f;
    private IEnumerator currentCoroutine;
    private bool coroutineLock;
    private bool shouldWrite = true;
    private bool skipRequested = false;

    void Awake()
    {
        textBox.text = "";
    }

    public void AdvanceText()
    {
        currentTextIndex++;
        if (currentTextIndex >= textList.Length)
        {
            currentTextIndex = -1;
            textBox.text = "";
            shouldWrite = false;
        }
        else
        {
            // todo: make textbox start sound
            StartCoroutine(WriteText());
        }
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
