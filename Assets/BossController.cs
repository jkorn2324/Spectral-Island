using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int BossIndex;
    private int PhaseIndex;
    public float hp = 0f;
    public Slider hpSlider;
    private float targetHp;
    public float hpPerSecond = 0.5f;
    private bool changingHp = false;
    public TypeWriter Writer;
    // used to check if player has gone through text
    public bool scriptSeen = false;
    // Start is called before the first frame update
    void Start()
    {
        Writer = FindObjectOfType<TypeWriter>();
        targetHp = hp;
        AttachToWriter();
    }

    public void AttachToWriter()
    {
        Writer.Boss = this;
        PhaseIndex = 0;
        Writer.SetText(BossIndex, PhaseIndex, 0);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptSeen)
        {
            // todo: make this also do player choices
            // here we can also set triggers for things to happen after stuff is seen.. music start perhaps?
            PhaseIndex++;
            if (PhaseIndex == 5) // this doesn't exist
            {
                // this boss is done
                // todo: transition away?
            }
            else
            {
                Writer.SetText(BossIndex, PhaseIndex, 0);
            }
            scriptSeen = false;
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
    }
}
