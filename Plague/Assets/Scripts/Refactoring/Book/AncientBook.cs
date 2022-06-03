using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientBook : MonoBehaviour
{
    private float _decriptionLevel = 0f;


    private void SetDecriptionLevel(float level)
    {
        _decriptionLevel = level;
    }

    public void AddDecriptionLevel(float level)
    {
        _decriptionLevel += level;
    }
    
}
