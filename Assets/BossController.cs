using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public float hp = 0f;
    public Slider hpSlider;
    private float targetHp;
    public float hpPerSecond = 0.5f;
    private bool changingHp = false;
    public TypeWriter Writer;
    // Start is called before the first frame update
    void Start()
    {
        Writer = FindObjectOfType<TypeWriter>();
        targetHp = hp;
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
