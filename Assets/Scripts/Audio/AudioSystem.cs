using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The hacky audio system.
/// </summary>
[RequireComponent(typeof(Animator))]
public class AudioSystem : MonoBehaviour
{

    /// <summary>
    /// Static wrapper to easily play any oneOff AudioClip
    /// </summary>
    public static void playOneOff(string name)
    {
        if (_theAudioSystem == null)
        {
            _theAudioSystem = FindObjectOfType<AudioSystem>();
        }

        _theAudioSystem?.playOneOffHelper(name);
    }

    private static AudioSystem _theAudioSystem = null;

    [SerializeField]
    private AudioTrackData trackData;

    private AudioTrack _tracks;
    private Dictionary<string, AudioSource> _nameToOneOffSource = new Dictionary<string, AudioSource>();

    /// <summary>
    /// Easy hook to play any oneOff AudioClip
    /// </summary>
    public void playOneOffHelper(string name, float volumeScale=1.0f)
    {
        AudioSource source;
        if (_nameToOneOffSource.TryGetValue(name, out source))
        {
            if (!source.isPlaying)
            {
                source.volume = volumeScale;
                source.Play();
            }
        }
        else
        {
            Debug.LogError($"Missing oneOff clip with name {name}");
        }
    }

    /// <summary>
    /// Called when the audio system is called.
    /// </summary>
    private void Start()
    {
        this._tracks = new AudioTrack(trackData, this);
        this._tracks.HookEvents();

        if(this.trackData.PlayOnAwake)
        if (this.trackData.PlayOnAwake)
        {
            this._tracks.Play();
        }

        foreach(AudioClip clip in Resources.LoadAll<AudioClip>("Audio")){
            AudioSource a = this.gameObject.AddComponent<AudioSource>();
            a.clip = clip;
            a.loop = false;
            _nameToOneOffSource.Add(clip.name, a);
        }
    }

    private void OnEnable()
    {
        if(this._tracks != null)
        {
            this._tracks.HookEvents();
        }
    }

    private void OnDisable()
    {
        this._tracks.UnHookEvents();
    }

    /// <summary>
    /// Updates the audio system.
    /// </summary>
    private void Update()
    {
        this._tracks?.Update();
    }
}
