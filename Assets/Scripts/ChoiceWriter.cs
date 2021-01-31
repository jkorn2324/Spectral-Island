using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceWriter : MonoBehaviour
{
    public GlobalGameStateManager GameState;
    public BossController Boss; // this needs to be set each time by the Boss when it initializes
    public Transform Loc1;
    public GameObject Selector1;
    public Text Option1;
    public Transform Loc2;
    public GameObject Selector2;
    public Text Option2;
    private int selection = 0;
    public bool hasChoiceToMake = false;
    public int stateKey;
    public ScriptData Script;
    public CanvasGroup Canvas;
    private bool reversed = false;


    // Start is called before the first frame update
    void Start()
    {
        GameState = FindObjectOfType<GlobalGameStateManager>();
        InitWriter(false);
        Script = FindObjectOfType<ScriptData>();
    }

    public void SetChoice(int state)
    {
        // randomly swap locations
        if (Random.value > 0.5f)
        {
            Vector3 pos1 = Loc1.position;
            Loc1.position = Loc2.position;
            Loc2.position = pos1;
            reversed = !reversed;
        }
        InitWriter(true);
        hasChoiceToMake = true;
        stateKey = state;
        int key1 = state * 10 + 1;
        int key2 = state * 10 + 2;
        Option1.text = Script.playerResponseMap[key1];
        Option2.text = Script.playerResponseMap[key2];
    }
    // Update is called once per frame
    void Update()
    {
        if (GameState.GameMode == GlobalGameStateManager.gameMode.battle)
        {
            if (hasChoiceToMake)
            {
                // wait for the choice
                if ((Input.GetButtonDown("Down") && !Input.GetButtonDown("Up")) || (Input.GetButtonDown("Up") && !Input.GetButtonDown("Down")))
                {
                    SwapSelection();
                }
                if (Input.GetButtonDown("Interact"))
                {
                    Boss.SetChoice(selection + 1); // remember that these are 1-indexed
                    InitWriter(false);
                }
            }
            else
            {
                // do nothing
            }
        }
    }

    public void InitWriter(bool hasChoiceToMake)
    {
        if (reversed)
        {
            Selector2.SetActive(true);
            Selector1.SetActive(false);
        }
        else
        {
            Selector1.SetActive(true);
            Selector2.SetActive(false);
        }

        selection = reversed ? 1 : 0;
        this.hasChoiceToMake = hasChoiceToMake;
        Canvas.alpha = hasChoiceToMake ? 1f : 0f;
    }

    public void SwapSelection()
    {
        selection = (selection + 1) % 2;
        if (selection == 0)
        {
            Selector1.SetActive(true);
            Selector2.SetActive(false);
        }
        else
        {
            Selector1.SetActive(false);
            Selector2.SetActive(true);
        }
    }
}
