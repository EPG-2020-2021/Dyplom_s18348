using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; //single instance


    //[SerializeField]
    //internal



    private void Awake()
    {
        if (!instance) //singletone
        {
            instance = this;
        }
    }



}
