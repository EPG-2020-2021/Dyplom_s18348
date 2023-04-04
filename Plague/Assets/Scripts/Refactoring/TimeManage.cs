using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour
{
    public GameObject daynnightCircle;
    public float dayinmins = 25f;

    public static string time = "12:00";

    float rotation = 0f;
    float lastrotation = 0f;

    // Update is called once per frame
    void Update()
    {
        var times = time.Split(':');
        int hours = int.Parse(times[0]);
        int minutes = int.Parse(times[1]);

        
        rotation = ((hours-2) * 15f + (minutes * 0.25f));
        daynnightCircle.transform.rotation = Quaternion.Euler(0,0,rotation);
        


        if (Time.time - lastrotation > ((dayinmins * 60f) / 1440f))
        {
            time = hours + ":" + (minutes+=1);
            lastrotation = Time.time;
            print(time);
        }
        if(minutes >= 60)
        {
            time = (hours += 1) + ":00";
        }
        if (hours >= 24)
        {
            time = "00:00";
        }

        
    }



    //Delgates for night and day
}
