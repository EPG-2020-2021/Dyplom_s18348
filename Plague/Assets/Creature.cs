using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public string Name;
    string type;

    
    
    void Start()
    {
        type = gameObject.GetComponent<DropDown>().GetType();
        Debug.Log(type);
    }


    void Update()
    {
        
    }
}
