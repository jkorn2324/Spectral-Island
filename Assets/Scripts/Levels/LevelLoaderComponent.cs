using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The level loader component used to update the level loader static class.
/// </summary>
public class LevelLoaderComponent : MonoBehaviour
{
    [SerializeField]
    private LevelLoaderReference reference;

    private static bool _instantiated = false;

    private void Start()
    {
        if (_instantiated)
        {
            Destroy(this.gameObject);
            return;
        }

        _instantiated = true;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        this.reference.Loader?.Update();

        IEnumerator asyncLoadLevel = this.reference.Loader?.EnumerateLoadSceneAsync();
        if (asyncLoadLevel != null)
        {
            this.StartCoroutine(asyncLoadLevel);
        }
    }
}
