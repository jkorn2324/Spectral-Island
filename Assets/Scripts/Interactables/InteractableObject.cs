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
    private float interactableWidth;
    [SerializeField]
    private float interactableHeight;
    [SerializeField]
    private int requiredItem = 0;
    [SerializeField]
    private string interactableType;
    [SerializeField]
    private InteractedSound interactedSound;

    private AudioSource _audioSource;

    private Rect _interactedHitbox;

    private GlobalGameStateManager _gameState;
    private OverworldTypewriter _typeWriter;

    private void Start()
    {
        this._gameState = FindObjectOfType<GlobalGameStateManager>();
        this._typeWriter = FindObjectOfType<OverworldTypewriter>();

        this._audioSource = this.GetComponent<AudioSource>();

        Vector3 position = this.transform.position;
        
        this._interactedHitbox = new Rect();
        this._interactedHitbox.x = position.x - (interactableWidth / 2.0f);
        this._interactedHitbox.y = position.y + (interactableHeight / 2.0f);
        this._interactedHitbox.width = interactableWidth;
        this._interactedHitbox.height = interactableHeight;

        this.OnStart();
    }

    protected virtual void OnStart() { }

    /// <summary>
    /// Called when the object is enabled.
    /// </summary>
    private void OnEnable()
    {
        InteractableObjectSet.AddInteractableObject(this);
    }

    /// <summary>
    /// Called when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
        InteractableObjectSet.RemoveInteractableObject(this);
    }

    /// <summary>
    /// Determines whether the interactable object's interaction hitbox
    /// overlaps with the input rectangle.
    /// </summary>
    /// <param name="controller">The input rectangle..</param>
    /// <returns>A boolean that returns true if they overlap.</returns>
    public bool IsOverlappingWith(Rect rect)
    {
        return rect.Overlaps(this._interactedHitbox);
    }

    protected virtual bool CanInteract(PlayerController controller)
    {
        return this.requiredItem == 0 || this._gameState.HasItem(this.requiredItem);
    }

    /// <summary>
    /// Called when the object interacts with the player.
    /// </summary>
    /// <param name="controller">The player controller.</param>
    public void OnInteract(PlayerController controller)
    {
        if(this.CanInteract(controller))
        {
            this.OnInteractSuccess(controller);
        }
    }

    protected virtual void OnInteractSuccess(PlayerController controller) 
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
                break;
            case "generic_message":
                // this._typeWriter.SetText(interactableType);
                break;
            case "generic_boss":
                // this._typeWriter.SetText(interactableType);
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
