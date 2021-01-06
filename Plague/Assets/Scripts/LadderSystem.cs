using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSystem : MonoBehaviour
{
    public GameObject aimPoint;

    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && player!=null)
        {
            player.transform.position = aimPoint.transform.position;
        }
    }
}
