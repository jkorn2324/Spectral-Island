using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioTransitionData
{
    [SerializeField]
    public float transitionOffset;
    [SerializeField]
    public string trackChannelFrom;
    [SerializeField]
    public string trackChannelTo;
    [SerializeField, Range(0.0f, 20f)]
    public float transitionTime;
}

/// <summary>
/// The hacky audio system.
/// </summary>
[RequireComponent(typeof(Animator))]
public class AudioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioTracksData trackData;
    private AudioTracksSet _tracks;

    [SerializeField]
    private AudioTransitionData transitionData;

    /// <summary>
    /// Called when the audio system is called.
    /// </summary>
    private void Start()
    {
        this._tracks = new AudioTracksSet(trackData, this);
        this._tracks.Play();

        StartCoroutine(this.Transition(this.transitionData.transitionOffset));
    }

    private IEnumerator Transition(float delay)
    {
        yield return new WaitForSeconds(delay);
        this._tracks.BeginTransition(
            transitionData.trackChannelFrom, transitionData.trackChannelTo, transitionData.transitionTime);
    }

    /// <summary>
    /// Updates the audio system.
    /// </summary>
    private void Update()
    {
        this._tracks.Update();
    }
}
