using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leech : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 startPosition;
    public Sprite drinkingLeech;
    GameObject leech;
    bool dropable = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.CompareTag("LeechArea");
        dropable = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.CompareTag("LeechArea");
        dropable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D ray = Physics2D.Raycast(Input.mousePosition, Camera.main.transform.forward, 1000);
            Debug.DrawRay(Input.mousePosition, Camera.main.transform.forward, Color.green ,10);
            if (ray.collider.CompareTag("Leech"))
            {
                print(ray.collider.name);
                leech = ray.collider.gameObject;
            }
        }



        if (Input.GetKeyUp(KeyCode.Mouse0) && leech)
        {
            if (dropable)
            {
                leech.GetComponent<Image>().sprite = drinkingLeech;
                




            }
            else
            {
                leech.transform.position = startPosition;
            }
            leech.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            leech = null;
        }



        if (leech)
        {
            Vector2 direction = (Input.mousePosition - leech.transform.position);
            leech.GetComponent<Rigidbody2D>().velocity = direction * 1000f * Time.deltaTime;
        }

    }


}
