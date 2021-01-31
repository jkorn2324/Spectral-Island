using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    GlobalGameStateManager GameState;
    public int BossIndex; // THIS MUST BE 1-INDEXED
    private int currentScriptKey;
    public float hp = 0f;
    public Slider hpSlider;
    private float targetHp;
    public float hpPerSecond = 0.5f;
    private bool changingHp = false;
    public TypeWriter NpcWriter;
    public ChoiceWriter ChoiceWriter;
    private int playerChoice = 0;
    public Animator animator;
    private bool waitingForChoice = false;
    private bool sentChoiceRequest = false;
    // used to check if player has gone through text
    public bool scriptSeen = false;
    // Start is called before the first frame update
    void Start()
    {
        GameState = FindObjectOfType<GlobalGameStateManager>();
        NpcWriter = FindObjectOfType<TypeWriter>();
        ChoiceWriter = FindObjectOfType<ChoiceWriter>();
        targetHp = hp;
        AttachToWriter();
    }

    public void SetChoice(int choice)
    {
        waitingForChoice = false;
        ChangeHp(choice == 0 ? -0.5f : 0.5f);
        playerChoice = choice;

    }

    public void AttachToWriter()
    {
        NpcWriter.Boss = this;
        currentScriptKey = BossIndex;
        NpcWriter.SetText(currentScriptKey);
    }

    public void ChangeHp(float delta)
    {
        if (targetHp != hp)
        {
            targetHp += delta;
        }
        else
        {
            targetHp = hp + delta;
        }
        targetHp = Mathf.Clamp(targetHp, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.GameMode == GlobalGameStateManager.gameMode.battle)
        {
            if (scriptSeen)
            {
                // here we can also set triggers for things to happen after stuff is seen.. music stuff perhaps?
                if (currentScriptKey > 1000)
                {
                    // we're at the end of the script sequence
                    // todo: get out of this fight. should update any flags and ask the globalgamestatemanager to swap us back to the overworld state
                    if (hp != targetHp)
                    {
                        // wait for hp to update
                    }
                    else
                    {
                        scriptSeen = false;
                        if (hp == 1f)
                        {
                            // success, give item
                            GameState.GiveItem(BossIndex);
                        }
                        GameState.GameMode = GlobalGameStateManager.gameMode.overworld;
                    }
                }
                else
                {
                    // wait for the player to pick something. for now, this is just always 1
                    if (!sentChoiceRequest)
                    {
                        ChoiceWriter.SetChoice(currentScriptKey);
                        waitingForChoice = true;
                        sentChoiceRequest = true;
                    }
                    else
                    {
                        if (waitingForChoice)
                        {
                            // wait patiently
                        }
                        else
                        {
                            currentScriptKey *= 10;
                            currentScriptKey += playerChoice;
                            NpcWriter.SetText(currentScriptKey);
                            scriptSeen = false; // once player has picked, we can set scriptSeen to false for the next round of text
                            sentChoiceRequest = false;
                            waitingForChoice = false;
                            playerChoice = 0;
                        }
                    }
                }
            }
            // hp updates
            if (hp != targetHp)
            {
                float origHp = hp;
                float deltaHp = targetHp - hp;
                hp += Mathf.Sign(deltaHp) * hpPerSecond;
                // check for overshoot
                if (Mathf.Sign(hp - origHp) == Mathf.Sign(hp - targetHp))
                {
                    hp = targetHp;
                }
            }
            hpSlider.value = hp == 0 ? 0.01f : hp;
            animator.SetFloat("hp", hp); // you can use this animator to set the sprite based on the hp, probably in discrete steps
        }
    }
}
