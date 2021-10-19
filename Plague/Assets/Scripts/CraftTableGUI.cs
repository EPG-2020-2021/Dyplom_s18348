using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftTableGUI : MonoBehaviour
{

    bool interactible = false;
    public GameObject player;

    GameObject CTgui;
    // Start is called before the first frame update
    void Start()
    {
        CTgui = GameObject.Find("Canvas").transform.Find("CraftTableInventory").gameObject;      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            interactible = true;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            interactible = false;
            CTgui.SetActive(false);
        }



    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactible)
        {
         
            Debug.Log("Interaction with CraftTable");
            CTgui.SetActive(true);
           
            


        }
    }
}
