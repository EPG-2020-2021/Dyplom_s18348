using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    public Quest quest;
   
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {

             
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        quest.finishAction(); 
       



    }
}
