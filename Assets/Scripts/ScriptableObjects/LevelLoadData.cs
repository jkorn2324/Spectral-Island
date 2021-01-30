using UnityEngine;

[System.Serializable]
public struct LevelTransitionData
{
    [SerializeField]
    private bool displayTransition;
    [SerializeField]
    private string transitionName;

    public string TransitionName
        => this.transitionName;

    public bool DisplayTransition
        => this.displayTransition;
}

/// <summary>
/// The level load data.
/// </summary>
[CreateAssetMenu(fileName = "Level Load Data", menuName = "Levels/Level Load Data")]
public class LevelLoadData : ScriptableObject
{
    [SerializeField]
    private string levelToLoad;
    [SerializeField]
    private bool showLoadingScreen;

    [SerializeField]
    private float minLoadTime;
    [SerializeField]
    private float maxLoadTime;

    [SerializeField]
    private LevelTransitionData transitions;

    public string LevelToLoad
        => this.levelToLoad;

    public bool ShowLoadingSceen
        => this.showLoadingScreen;

    public LevelTransitionData Transitions
        => this.transitions;

    public float RandomLoadTime
        => Random.Range(this.minLoadTime, this.maxLoadTime);
}
