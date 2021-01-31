using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Audio transition class.
/// </summary>
public class AudioTransition
{
    private AudioTrack _a, _b;

    private float _maxTransitionTime;
    private float _currentTransitionTime;

    private float _endBVolume;
    private float _startAVolume;
    
    private float TransitionPercentage
        => this._currentTransitionTime / this._maxTransitionTime;

    public bool IsFinished
        => this.TransitionPercentage >= 1.0f;
    
    public AudioTransition(AudioTrack a, AudioTrack b, float transitionTime)
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
            this._startAVolume, 0.0f, this._currentTransitionTime);
        float currentBVolume = Mathf.Lerp(
            0.0f, this._endBVolume, this._currentTransitionTime);
        
        this._a.Volume = currentAVolume;
        this._b.Volume = currentBVolume;
    }
}
