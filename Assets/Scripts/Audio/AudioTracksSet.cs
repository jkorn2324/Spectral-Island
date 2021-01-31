using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


/// <summary>
/// Defines an audio track.
/// </summary>
public class AudioTrack
{
    private AudioSystem _system;
    private AudioClip _clip;
    private string _trackName;

    private float _activeVolume;
    private float _volume;

    private GameObject _trackGameObject = null;
    private AudioSource _trackSource = null;

    public float Volume
    {
        get => this._volume;
        set => this._volume = value;
    }

    public float ActiveVolume
        => this._activeVolume;

    public string TrackName
        => this._trackName;

    public AudioTrack(AudioTracksData.AudioTrackData trackData, AudioSystem system)
    {
        this._clip = trackData.clip;
        this._trackName = trackData.trackName;
        this._system = system;
        this._volume = Convert.ToInt32(trackData.active) * trackData.activeVolume;
        this._activeVolume = trackData.activeVolume;
        this.CreateTrack();
    }

    /// <summary>
    /// Creates a track.
    /// </summary>
    private void CreateTrack()
    {
        this._trackGameObject = new GameObject("DynamicTrack_" + this._trackName);
        this._trackSource = this._trackGameObject.AddComponent<AudioSource>();
        this._trackSource.clip = this._clip;
        this._trackSource.volume = this.Volume;
        this._trackGameObject.transform.SetParent(this._system.transform);
    }

    /// <summary>
    /// Updates the audio track.
    /// </summary>
    public void Update()
    {
        if(this._trackSource != null)
        {
            this._trackSource.volume = this.Volume;
        }
    }

    /// <summary>
    /// Called when the tracks have begun.
    /// </summary>
    public void OnTrackBegin()
    {
        this._trackSource.Play();
    }

    /// <summary>
    /// Called when the tracks are paused.
    /// </summary>
    /// <param name="paused">Paused value.</param>
    public void OnTrackPaused(bool paused)
    {
        if (paused)
        {
            this._trackSource.Pause();
            return;
        }
        this._trackSource.UnPause();
    }

    /// <summary>
    /// Called when the track has been stopped.
    /// </summary>
    public void OnTrackStopped()
    {
        this._trackSource.Stop();
    }
}


[System.Serializable]
public struct AudioTracksData
{

    [System.Serializable]
    public struct AudioTrackData
    {
        [SerializeField]
        public AudioClip clip;
        [SerializeField]
        public string trackName;
        [SerializeField, Range(0.0f, 1.0f)]
        public float activeVolume;
        [SerializeField]
        public bool active;
    }

    [SerializeField]
    private List<AudioTrackData> tracks;

    public void GenerateTracks(ref Dictionary<string, AudioTrack>outTracks, AudioSystem system)
    {
        foreach (AudioTrackData t in this.tracks)
        {
            if (t.clip != null)
            {
                AudioTrack track = new AudioTrack(t, system);
                outTracks.Add(t.trackName, track);
            }
        }
    }
}


/// <summary>
/// The Audio track set.
/// </summary>
public class AudioTracksSet
{
    private Dictionary<string, AudioTrack> _tracks;
    private List<AudioTransition> _transitions;

    private AudioSystem _parentSystem;

    public AudioTracksSet(AudioTracksData data, AudioSystem system)
    {
        this._tracks = new Dictionary<string, AudioTrack>();
        data.GenerateTracks(ref this._tracks, system);
        this._transitions = new List<AudioTransition>();
        this._parentSystem = system;
    }

    public void Play()
    {
        foreach(AudioTrack t in this._tracks.Values)
        {
            t.OnTrackBegin();
        }
    }

    public void Stop()
    {
        foreach(AudioTrack t in this._tracks.Values)
        {
            t.OnTrackStopped();
        }
    }

    public void Pause(bool paused)
    {
        foreach(AudioTrack t in this._tracks.Values)
        {
            t.OnTrackPaused(paused);
        }
    }

    public AudioTrack GetAudioTrack(string trackName)
    {
        if(this._tracks.ContainsKey(trackName))
        {
            return this._tracks[trackName];
        }
        return null;
    }

    public AudioTrack GetAudioTrack(int index)
    {
        if(this._tracks.Count <= index || index < 0)
        {
            return null;
        }

        int currentIndex = 0;
        foreach(AudioTrack t in this._tracks.Values)
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
        // Updates the tracks.
        foreach(AudioTrack track in this._tracks.Values)
        {
            track.Update();
        }

        // Updates the time.
        float deltaTime = Time.deltaTime;
        for(int i = this._transitions.Count - 1; i >= 0; i--)
        {
            AudioTransition transition = this._transitions[i];
            transition.Update(deltaTime);
            if(transition.IsFinished)
            {
                this._transitions.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Transitions between one track to another.
    /// </summary>
    /// <param name="trackNameA">Track name A.</param>
    /// <param name="trackNameB">Track name B.</param>
    /// <param name="trackBEndVolume">The end volume of the second track.</param>
    /// <param name="totalTransitionTime">The total transition time.</param>
    public void BeginTransition(string trackNameA, string trackNameB, float totalTransitionTime = 2.0f)
    {
        AudioTrack trackA = this.GetAudioTrack(trackNameA);
        AudioTrack trackB = this.GetAudioTrack(trackNameB);

        if(trackA == null || trackB == null)
        {
            return;
        }

        AudioTransition newTransition = new AudioTransition(
            trackA, trackB, totalTransitionTime);
        this._transitions.Add(newTransition);
    }
}
