using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Defines an audio track.
/// </summary>
public class AudioChannel
{
    private ChannelClip _activeClip = null;
    private ChannelClip _originalClip = null;
    private Dictionary<string, ChannelClip> _clips;
    
    private AudioTransition _currentTransition = null;
    private AudioTrackData.AudioChannelData _data;

    private AudioTransitionManager _transitionManager;
    private AudioTrack _parentTrack;

    private float _volume;
    private GameObject _trackGameObject = null;

    public float Volume
    {
        get => this._volume;
        set => this._volume = value;
    }

    public float Duration
        => this._parentTrack.CurrentDuration;

    public string ChannelName
        => this._data.channelName;

    public GameObject TrackParentGameObject
        => this._trackGameObject;

    private ChannelClip OriginalClip
    {
        get => this._originalClip;
    }

    public AudioChannel(AudioTrackData.AudioChannelData channelData, AudioTrack parentTrack, AudioSystem parent)
    {
        this._clips = new Dictionary<string, ChannelClip>();
        this._parentTrack = parentTrack;
        this._transitionManager = new AudioTransitionManager(channelData, this);
        this._data = channelData;
        this.CreateChannel(parent);
    }

    public void HookEvents()
    {
        this._transitionManager.HookEvents();
    }

    public void UnHookEvents()
    {
        this._transitionManager.UnHookEvents();
    }

    /// <summary>
    /// Creates a track.
    /// </summary>
    private void CreateChannel(AudioSystem parent)
    {
        this._trackGameObject = new GameObject("DynamicChannel" + this.ChannelName);
        this._trackGameObject.transform.SetParent(parent.transform);

        foreach(AudioTrackData.AudioChannelData.ChannelClip clip in this._data.clips)
        {
            ChannelClip newClip = new ChannelClip(this, clip);
            if(this._activeClip == null)
            {
                this._originalClip = this._activeClip = newClip;
            }
            this._clips.Add(clip.clipName, newClip);
        }
    }

    /// <summary>
    /// Updates the audio track.
    /// </summary>
    public void Update(TrackState state, bool paused)
    {
        float deltaTime = Time.deltaTime;
        this._transitionManager.Update(deltaTime);

        if (state == TrackState.STATE_PLAYING
            && !paused)
        {
            if(this._currentTransition != null)
            {
                this._currentTransition.Update(deltaTime);
                if(this._currentTransition.IsFinished)
                {
                    this._activeClip = this._clips[this._currentTransition.NewActiveClip.ClipName];
                    this._currentTransition = null;
                }
            }
        }

        foreach(ChannelClip clip in this._clips.Values)
        {
            clip.Update(deltaTime);
        }
    }

    /// <summary>
    /// Called when the tracks have begun.
    /// </summary>
    public void OnTrackBegin()
    {
        //this._activeClip = this.OriginalClip;
        foreach(ChannelClip clip in this._clips.Values)
        {
            clip.OnTrackBegin(this._activeClip.ClipName == clip.ClipName);
        }
    }

    /// <summary>
    /// Called when the tracks are paused.
    /// </summary>
    /// <param name="paused">Paused value.</param>
    public void OnTrackPaused(bool paused)
    {
        foreach(ChannelClip clip in this._clips.Values)
        {
            clip.OnTrackPaused(paused);
        }
    }

    /// <summary>
    /// Called when the track has been stopped.
    /// </summary>
    public void OnTrackStopped()
    {
        foreach (ChannelClip clip in this._clips.Values)
        {
            clip.OnTrackStopped();
        }
    }

    /// <summary>
    /// Transitions from one clip to another.
    /// </summary>
    /// <param name="newClip">The new clip.</param>
    /// <param name="transitionTime">The transition time.</param>
    public void BeginTransition(string newClip, float transitionTime)
    {
        if (this._currentTransition != null)
        {
            return;
        }

        if(this._clips.ContainsKey(newClip))
        {
            ChannelClip clip = this._clips[newClip];

            Debug.Log("Should begin transition.");
            Debug.Log("Clip: " + clip.ClipName);

            this._currentTransition = new AudioTransition(
                this._activeClip, clip, transitionTime);
        }
    }
}


/// <summary>
/// Updates the channel clip data.
/// </summary>
public class ChannelClip
{
    private AudioTrackData.AudioChannelData.ChannelClip _currentClip;
    private AudioChannel _parentChannel;

    private GameObject _clipGameObject = null;
    private AudioSource _clipAudioSource = null;

    private float _currentVolume = 0.0f;

    public string ClipName
        => this._currentClip.clipName;

    public float ActiveVolume
        => this._currentClip.activeVolume;

    public float Volume
    {
        get => this._currentVolume;
        set => this._currentVolume = value;
    }

    public ChannelClip(AudioChannel channel, AudioTrackData.AudioChannelData.ChannelClip clip)
    {
        this._currentClip = clip;
        this._parentChannel = channel;
        this.CreateGameObject();
    }

    private void CreateGameObject()
    {
        this._clipGameObject = new GameObject(this._currentClip.clipName);
        this._clipAudioSource = this._clipGameObject.AddComponent<AudioSource>();
        this._clipAudioSource.loop = true;
        this._clipAudioSource.clip = this._currentClip.clip;
        this._clipAudioSource.volume = this._currentVolume;
        this._clipAudioSource.playOnAwake = false;
        this._clipGameObject.transform.SetParent(this._parentChannel.TrackParentGameObject.transform);
    }

    public void Update(float deltaTime)
    {
        if(this._clipAudioSource != null)
        {
            this._clipAudioSource.volume = this._currentVolume;
        }
    }

    public void OnTrackBegin(bool isActive)
    {
        this._currentVolume = isActive ? this.ActiveVolume : 0.0f;
        this._clipAudioSource.Play();
    }

    public void OnTrackPaused(bool paused)
    {
        if(paused)
        {
            this._clipAudioSource.Pause();
            return;
        }
        this._clipAudioSource.UnPause();
    }

    public void OnTrackStopped()
    {
        this._clipAudioSource?.Stop();
    }
}
