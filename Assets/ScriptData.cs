using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptData : MonoBehaviour
{
    // first index is boss number
    // second index is phase
    // third index is pos/neg
    public string[,,,] textArray = new string[,,,]
    {
        // drowned
        {
            // phase intro (no pos/neg)
            {
                // pos
                { },
                // neg
                { }, // LEAVE EMPTY
            },
            // phase 1
            {
                // pos
                { },
                // neg
                { },
            },
            // phase 2
            {
                // pos
                { },
                // neg
                { },
            },
            // phase 3
            {
                // pos
                { },
                // neg
                { },
            },
            // phase end
            {
                // pos
                { },
                // neg
                { },
            },
        },
        // stabbed
        {
            // phase intro (no pos/neg)
            {
                // pos
                { },
                // neg
                { }, // LEAVE EMPTY
            },
            // phase 1
            {
                // pos
                { },
                // neg
                { },
            },
            // phase 2
            {
                // pos
                { },
                // neg
                { },
            },
            // phase 3
            {
                // pos
                { },
                // neg
                { },
            },
            // phase end
            {
                // pos
                { },
                // neg
                { },
            },
        },

    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
