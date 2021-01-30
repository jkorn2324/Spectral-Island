using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main menu manager.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private LevelLoaderReference levelLoaderReference;

    /// <summary>
    /// Called when the play button was pressed.
    /// </summary>
    /// <param name="levelLoadData">The level load data.s</param>
    public void OnPlayButtonPressed(LevelLoadData levelLoadData)
    {
        this.levelLoaderReference.Loader?.LoadLevel(levelLoadData);
    }
}
