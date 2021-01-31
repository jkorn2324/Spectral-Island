using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverworldTypewriter : MonoBehaviour
{
    [SerializeField]
    private LevelLoaderReference levelLoaderReference;
    [SerializeField]
    private LevelLoadData mainToMainMenuLoad;

    public GlobalGameStateManager GameState;
    public Text textBox;
    string[] textList;
    public ScriptData Script;
    int currentTextIndex = -1;
    public float typewriterDelay = 0.05f;
    private IEnumerator currentCoroutine;
    private bool coroutineLock;
    private bool shouldWrite;
    private bool skipRequested = false;
    public CanvasGroup Canvas;
    public int QueuedBoss = -1;
    private bool lastText = false;


    void Awake()
    {
        GameState = FindObjectOfType<GlobalGameStateManager>();
        textList = new string[] { };
        InitTypewriter(false);
        Script = FindObjectOfType<ScriptData>();
    }

    public void SetText(string key)
    {
        GameState.ControlsLocked = true;
        InitTypewriter(true);
        textList = Script.overworldTextMap[key];
        if (key == "gotend")
        {
            lastText = true;
        }
    }

    public void AdvanceText()
    {
        currentTextIndex++;
        if (currentTextIndex >= textList.Length)
        {
            InitTypewriter(false);
            if (QueuedBoss != -1)
            {
                GameState.ActivateBoss(QueuedBoss);
                QueuedBoss = -1;
            }
            GameState.ControlsLocked = false;
            if (lastText)
            {
                Debug.Log("Game Over");
                this.levelLoaderReference.Loader?.LoadLevel(this.mainToMainMenuLoad);
            }
        }
        else
        {
            // todo: make textbox start sound
            AudioSystem.playOneOff("writing");
            StartCoroutine(WriteText());
        }
    }

    public void InitTypewriter(bool shouldWrite)
    {
        textBox.text = "";
        this.shouldWrite = shouldWrite;
        currentTextIndex = -1;
        if (shouldWrite)
        {
            Canvas.alpha = 1f;
        }
        else
        {
            Canvas.alpha = 0f;
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
        if (GameState.GameMode == GlobalGameStateManager.gameMode.overworld)
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
                        AudioSystem.playOneOff("confirm");
                        AdvanceText();
                    }
                }
                else if (Input.GetButtonDown("Interact")) // player skip
                {
                    if (skipRequested == false)
                    {
                        // audio feedback that skip is requested
                        AudioSystem.playOneOff("select");
                    }
                    
                    skipRequested = true;
                }
            }
        }
    }
}