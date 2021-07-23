using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public bool DestroyOld, DestroyNew;

    void Awake()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (obj.Length > 1)
        {
            if (DestroyOld)
            {
                Destroy(obj[0].gameObject);
                return;
            }
            else if (DestroyNew)
            {
                Destroy(gameObject);
                return;
            }           
        }

        DontDestroyOnLoad(gameObject);
    }
}
