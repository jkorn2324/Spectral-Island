using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The credits manager.
/// </summary>
public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    private LevelLoaderReference levelLoaderReference;
    [SerializeField]
    private LevelLoadData exitCreditsData;
    [SerializeField]
    private KeyCode exitCreditsKey;


    private void Update()
    {
        if(Input.GetKeyDown(exitCreditsKey))
        {
            this.ExitCredits(this.exitCreditsData);
        }
    }

    public void ExitCredits(LevelLoadData loadData)
    {
        this.levelLoaderReference.Loader?.LoadLevel(loadData);
    }
}
