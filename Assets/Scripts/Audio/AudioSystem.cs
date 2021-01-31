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

    private Dictionary<string, AudioClip> _nameToOneOff = new Dictionary<string, AudioClip>();
    private AudioSource _oneOffAudioSource = null;

    /// <summary>
    /// Easy hook to play any oneOff AudioClip
    /// </summary>
    public void playOneOffHelper(string name, float volumeScale=1.0f)
    {
        AudioClip clip;
        if (_nameToOneOff.TryGetValue(name, out clip))
        {
            if (!_oneOffAudioSource.isPlaying)
            {
                _oneOffAudioSource.PlayOneShot(clip, volumeScale);
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
            _nameToOneOff.Add(clip.name, clip);
        }
        this._oneOffAudioSource = this.gameObject.AddComponent<AudioSource>();
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
