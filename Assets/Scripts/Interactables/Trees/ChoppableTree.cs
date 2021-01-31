using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct TreeAudioClip
{
    [SerializeField]
    public AudioClip audioClip;
    [SerializeField, Range(0f, 1f)]
    public float volume;
}

[RequireComponent(typeof(AudioSource))]
public class ChoppableTree : InteractableObject
{
    [SerializeField]
    private TreeAudioClip chopTreeSound;

    private AudioSource _source;

    protected override void OnStart()
    {
        this._source = this.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called when the player interacts with the tree.
    /// </summary>
    /// <param name="controller">The player controller.</param>
    protected override void OnInteractSuccess(PlayerController controller)
    {
        this.PlaySound(this.chopTreeSound);
    }

    private void PlaySound(TreeAudioClip clip)
    {
        if (this._source.isPlaying)
        {
            this._source.Stop();
        }
        this._source.clip = clip.audioClip;
        this._source.volume = clip.volume;
        this._source.Play();
    }
}
