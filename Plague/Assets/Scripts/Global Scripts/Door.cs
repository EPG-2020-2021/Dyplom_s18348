using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string destination = "HomeInside";
    private bool interactible = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactible)
        {
            SceneManager.LoadScene(destination);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {     
            interactible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactible = false;
        }
    }
}
