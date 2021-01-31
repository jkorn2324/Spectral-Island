using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractedSound
{
    [SerializeField]
    public AudioClip audioClip;
    [SerializeField]
    public float volume;
}

/// <summary>
/// The interactable object monobehaviour.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private int requiredItem = 0;
    [SerializeField]
    private string interactableType;
    [SerializeField]
    private InteractedSound interactedSound;

    private AudioSource _audioSource;

    public BoxCollider2D InteractBox;
    private GlobalGameStateManager _gameState;
    private OverworldTypewriter _typeWriter;

    public void OnDrawGizmos()
    {
    }

    private void Start()
    {
        InteractBox = GetComponent<BoxCollider2D>();
        this._gameState = FindObjectOfType<GlobalGameStateManager>();
        this._typeWriter = FindObjectOfType<OverworldTypewriter>();

        this._audioSource = this.GetComponent<AudioSource>();

        Vector3 position = this.transform.position;
        
        this.OnStart();
    }

    protected virtual void OnStart() { }

    /// <summary>
    /// Called when the object is enabled.
    /// </summary>
    private void OnEnable()
    {
    }

    /// <summary>
    /// Called when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
    }

    public void InteractIfPossible()
    {
        Debug.Log("Interact if possible");
        if (requiredItem == 0 || _gameState.HasItem(requiredItem))
        {
            Interact();
        }
    }

    public void Interact() 
    {
        // TODO: Set this.
        this.PlaySound(this.interactedSound);

        switch(this.interactableType.Trim().ToLower())
        {
            case "cliff":
                // this._typeWriter.SetText(interactableType);
                break;
            case "tree":
                // TODO: remove the interactable
                // this._typeWriter.SetText(interactableType);
                Debug.Log("found tree");
                break;
            case "stabbed_boss":
                // this._typeWriter.SetText(interactableType);
                this._typeWriter.QueuedBoss = 1;
                break;
            case "drowned_boss":
                // this._typeWriter.SetText(interactableType);
                this._typeWriter.QueuedBoss = 2;
                break;
            case "strangled_boss":
                // this._typeWriter.SetText(interactableType);
                this._typeWriter.QueuedBoss = 3;
                break;
            case "burned_boss":
                // this._typeWriter.SetText(interactableType);
                this._typeWriter.QueuedBoss = 4;
                break;
            default:
                this._typeWriter.SetText(this.interactableType.Trim().ToLower());
                break;
        }
    }

    private void PlaySound(InteractedSound sound)
    {
        if(this.interactedSound.audioClip == null)
        {
            return;
        }

        if(this._audioSource.isPlaying)
        {
            this._audioSource.Stop();
        }

        this._audioSource.clip = this.interactedSound.audioClip;
        this._audioSource.volume = this.interactedSound.volume;
        this._audioSource.Play();
    }
}
