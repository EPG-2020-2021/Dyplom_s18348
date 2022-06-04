using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationDoor : MonoBehaviour
{
    public string destinationScene;



    public void LoadScene()
    {
        SceneManager.LoadScene(destinationScene);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }

}
