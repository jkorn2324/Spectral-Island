using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The hacky audio system.
/// </summary>
[RequireComponent(typeof(Animator))]
public class AudioSystem : MonoBehaviour
{
    [SerializeField]
    private AudioTrackData trackData;

    private AudioTrack _tracks;

    /// <summary>
    /// Called when the audio system is called.
    /// </summary>
    private void Start()
    {
        this._tracks = new AudioTrack(trackData, this);
        this._tracks.Play();
    }

    /// <summary>
    /// Updates the audio system.
    /// </summary>
    private void Update()
    {
        this._tracks.Update();
    }
}
