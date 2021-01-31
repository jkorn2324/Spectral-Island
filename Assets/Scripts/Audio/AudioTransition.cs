using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio transition class.
/// </summary>
public class AudioTransition
{
    private ChannelClip _a, _b;

    private float _maxTransitionTime;
    private float _currentTransitionTime;

    private float _endBVolume;
    private float _startAVolume;

    private float TransitionPercentage
        => this._currentTransitionTime / this._maxTransitionTime;

    public bool IsFinished
        => this.TransitionPercentage >= 1.0f;

    public ChannelClip NewActiveClip
        => this._b;

    public AudioTransition(ChannelClip a, ChannelClip b, float transitionTime)
    {
        this._a = a;
        this._b = b;

        this._endBVolume = b.ActiveVolume;
        this._startAVolume = a.Volume;

        this._currentTransitionTime = 0.0f;
        this._maxTransitionTime = transitionTime;
    }

    /// <summary>
    /// Updates the audio transition.
    /// </summary>
    /// <param name="deltaTime">The deltaTime.</param>
    public void Update(float deltaTime)
    {
        this._currentTransitionTime += deltaTime;

        float currentAVolume = Mathf.Lerp(
            this._startAVolume, 0.0f, this.TransitionPercentage);
        float currentBVolume = Mathf.Lerp(
            0.0f, this._endBVolume, this.TransitionPercentage);

        this._a.Volume = currentAVolume;
        this._b.Volume = currentBVolume;
    }
}

[System.Serializable]
public struct AudioTransitionData
{
    [SerializeField]
    public bool active;
    [SerializeField]
    public float startDuration;
    [SerializeField]
    public string transitionClip;
    [SerializeField, Range(0.0f, 20f)]
    public float transitionTime;

    public static bool operator <(AudioTransitionData a, AudioTransitionData b)
    {
        return a.startDuration < b.startDuration;
    }

    public static bool operator >(AudioTransitionData a, AudioTransitionData b)
    {
        return a.startDuration > b.startDuration;
    }

    public static bool operator <=(AudioTransitionData a, AudioTransitionData b)
    {

        return a.startDuration <= b.startDuration;
    }

    public static bool operator >=(AudioTransitionData a, AudioTransitionData b)
    {
        return a.startDuration >= b.startDuration;
    }
}

/// <summary>
/// The audio transition manager.
/// </summary>
public class AudioTransitionManager
{
    private List<AudioTransitionData> _transitions;
    private AudioChannel _parent;

    private float _previousDuration;

    public AudioTransitionManager(AudioTrackData.AudioChannelData channelData, AudioChannel parentChannel)
    {
        this._parent = parentChannel;
        this._transitions = channelData.channelTransitions;
        this._previousDuration = 0.0f;
    }

    public void Update(float deltaTime)
    {
        float currentDuration = this._parent.Duration;
        foreach (AudioTransitionData transitionData in this._transitions)
        {
            if(currentDuration >= transitionData.startDuration 
                && this._previousDuration <= transitionData.startDuration
                && transitionData.active)
            {
                this._parent.BeginTransition(transitionData.transitionClip, transitionData.transitionTime);
                break;
            }
        }
        this._previousDuration = currentDuration;
    }
}
