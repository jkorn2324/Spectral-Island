using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Demo script to demonstrate how events would work.
/// </summary>
public class EventCallerDemoScript : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToCall;
    [SerializeField]
    private float delay = 4;

    private void Start()
    {
        StartCoroutine(this.PlayAudio());
    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(this.delay);
        eventToCall?.Call();
    }
}
