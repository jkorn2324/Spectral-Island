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
public class AudioTransitionData
{
    [SerializeField]
    public bool active;

    [SerializeField]
    public bool useEvent = false;
    [SerializeField]
    public GameEvent eventTrigger;
    
    [SerializeField]
    public float startDuration;
    [SerializeField]
    public string transitionClip;
    [SerializeField, Range(0.0f, 20f)]
    public float transitionTime;
}

/// <summary>
/// Wrapper class used to contain the data also for hooking events.
/// </summary>
public class AudioTransitionDataWrapper
{
    private AudioTransitionData _transitionData;
    private AudioTransitionManager _transitionManager;

    public AudioTransitionData TransitionData
        => this._transitionData;

    public AudioTransitionDataWrapper(AudioTransitionData transitionData, AudioTransitionManager transitionManager)
    {
        this._transitionManager = transitionManager;
        this._transitionData = transitionData;
    }

    public void HookEvents()
    {
        if(this._transitionData.useEvent && this._transitionData.eventTrigger != null)
        {
            this._transitionData.eventTrigger += this.OnTriggeredEvent;
        }
    }

    public void UnHookEvents()
    {
        if (this._transitionData.useEvent && this._transitionData.eventTrigger != null)
        {
            this._transitionData.eventTrigger -= this.OnTriggeredEvent;
        }
    }

    /// <summary>
    /// Called when the event was triggered.
    /// </summary>
    public void OnTriggeredEvent()
    {
        if(!this._transitionData.active)
        {
            return;
        }
        this._transitionManager.BeginTransition(this._transitionData);
    }
}

/// <summary>
/// The audio transition manager.
/// </summary>
public class AudioTransitionManager
{
    private List<AudioTransitionDataWrapper> _transitions;
    private AudioChannel _parent;

    private float _previousDuration;

    public AudioTransitionManager(AudioTrackData.AudioChannelData channelData, AudioChannel parentChannel)
    {
        this._parent = parentChannel;
        
        this._transitions = new List<AudioTransitionDataWrapper>();
        foreach(AudioTransitionData data in channelData.channelTransitions)
        {
            AudioTransitionDataWrapper wrapper = new AudioTransitionDataWrapper(data, this);
            this._transitions.Add(wrapper);
        }

        this._previousDuration = 0.0f;
    }

    /// <summary>
    /// Hooks the event.
    /// </summary>
    public void HookEvents()
    {
        foreach(AudioTransitionDataWrapper wrapper in this._transitions)
        {
            wrapper.HookEvents();
        }
    }

    /// <summary>
    /// Unhooks the events.
    /// </summary>
    public void UnHookEvents()
    {
        foreach (AudioTransitionDataWrapper wrapper in this._transitions)
        {
            wrapper.UnHookEvents();
        }
    }

    /// <summary>
    /// Begins the transition using the transition data.
    /// </summary>
    /// <param name="transitionData">The transition data.</param>
    public void BeginTransition(AudioTransitionData transitionData)
    {
        this._parent.BeginTransition(transitionData.transitionClip, transitionData.transitionTime);
    }

    public void Update(float deltaTime)
    {
        float currentDuration = this._parent.Duration;
        foreach (AudioTransitionDataWrapper transitionDataWrapper in this._transitions)
        {
            AudioTransitionData transitionData = transitionDataWrapper.TransitionData;
            if(currentDuration >= transitionData.startDuration 
                && this._previousDuration <= transitionData.startDuration
                && !transitionData.useEvent)
            {
                this.BeginTransition(transitionData);
                break;
            }
        }
        this._previousDuration = currentDuration;
    }
}
