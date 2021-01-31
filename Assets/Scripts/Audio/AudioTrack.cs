using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>
/// The current track state.
/// </summary>
public enum TrackState
{
    STATE_IDLE,
    STATE_PLAYING,
    STATE_STOPPED
}

[System.Serializable]
public struct AudioTrackData
{
    [System.Serializable]
    public struct AudioChannelData
    {
        [System.Serializable]
        public struct ChannelClip
        {
            [SerializeField]
            public AudioClip clip;
            [SerializeField]
            public string clipName;
            [SerializeField, Range(0.0f, 1.0f)]
            public float activeVolume;
        }

        [SerializeField]
        public List<ChannelClip> clips;
        [SerializeField]
        public string channelName;
        [SerializeField]
        public bool active;
        [SerializeField]
        public List<AudioTransitionData> channelTransitions;
    }

    [SerializeField]
    private bool loopTracks;
    [SerializeField]
    private float trackDuration;
    [SerializeField]
    private List<AudioChannelData> channels;

    public bool LoopTracks
        => this.loopTracks;

    public float TrackDuration
        => this.trackDuration;

    public void GenerateChannels(ref Dictionary<string, AudioChannel> outTracks, AudioTrack track, AudioSystem system)
    {
        foreach (AudioChannelData t in this.channels)
        {
            if(t.clips.Count > 0)
            {
                AudioChannel channel = new AudioChannel(t, track, system);
                outTracks.Add(t.channelName, channel);
            }
        }
    }
}


/// <summary>
/// The Audio track set.
/// </summary>
public class AudioTrack
{
    private Dictionary<string, AudioChannel> _channels;
    private AudioTrackData _trackData;
    private TrackState _trackState;
    private bool _paused = false;
    
    private float _currentDuration = 0.0f;
    private AudioSystem _parentSystem;

    public bool IsPaused
        => this._paused;

    public float CurrentDuration
        => this._currentDuration;

    public TrackState TrackState
        => this._trackState;

    public AudioTrack(AudioTrackData data, AudioSystem system)
    {
        this._trackState = TrackState.STATE_IDLE;
        this._trackData = data;

        this._channels = new Dictionary<string, AudioChannel>();
        data.GenerateChannels(ref this._channels, this, system);
        this._parentSystem = system;
    }

    public void HookEvents()
    {
        foreach(AudioChannel t in this._channels.Values)
        {
            t.HookEvents();
        }
    }

    public void UnHookEvents()
    {
        foreach(AudioChannel t in this._channels.Values)
        {
            t.UnHookEvents();
        }
    }

    public void Play()
    {
        foreach(AudioChannel t in this._channels.Values)
        {
            t.OnTrackBegin();
        }

        this._paused = false;
        this._currentDuration = 0.0f;
        this._trackState = TrackState.STATE_PLAYING;
    }

    public void Stop()
    {
        foreach(AudioChannel t in this._channels.Values)
        {
            t.OnTrackStopped();
        }

        this._paused = false;
        this._currentDuration = 0.0f;
        this._trackState = TrackState.STATE_STOPPED;
    }

    public void Pause(bool paused)
    {
        foreach(AudioChannel t in this._channels.Values)
        {
            t.OnTrackPaused(paused);
        }
        this._paused = paused;
    }

    public AudioChannel GetAudioChannel(string channelName)
    {
        if(this._channels.ContainsKey(channelName))
        {
            return this._channels[channelName];
        }
        return null;
    }

    public AudioChannel GetAudioChannel(int index)
    {
        if(this._channels.Count <= index || index < 0)
        {
            return null;
        }

        int currentIndex = 0;
        foreach(AudioChannel t in this._channels.Values)
        {
            if(currentIndex++ == index)
            {
                return t;
            }
        }
        return null;
    }

    /// <summary>
    /// Updates the audio track.
    /// </summary>
    public void Update()
    {
        if(this._trackState == TrackState.STATE_PLAYING && !this._paused)
        {
            this._currentDuration += Time.deltaTime;
            // Updates the current duration.
            if(this._currentDuration >= this._trackData.TrackDuration)
            {
                Debug.Log("Duration is greater than tracks.");
                if(this._trackData.LoopTracks)
                {
                    this.Play();
                }
                else
                {
                    this.Stop();
                    return;
                }
            }
        }

        // Updates the tracks.
        foreach(AudioChannel channel in this._channels.Values)
        {
            channel.Update(this._trackState, this._paused);
        }
    }
}
