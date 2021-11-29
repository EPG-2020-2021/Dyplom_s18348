using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    [HideInInspector]
    public int arrayidx = 0;
    [HideInInspector]
    public string[] MyArray = new string[] { "StreetGuy", "Seller", "Librarian", "Sick" };

    public string GetType() {
        return MyArray[arrayidx]; 
    }
}

