using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour
{
    public GameObject daynnightCircle;
    private float dayinmins = 10f;

    public static string time = "12:00";

    private float rotation = 0f;
    private float lastrotation = 0f;

    public delegate void OnDayStart();
    public static OnDayStart onDayStartCallback;

    public delegate void OnNightStart();
    public static OnNightStart onNightStartCallback;

    // Update is called once per frame
    void Update()
    {
        var timeParts = time.Split(':');
        int hours = int.Parse(timeParts[0]);
        int minutes = int.Parse(timeParts[1]);

        
        rotation = ((hours-2) * 15f + (minutes * 0.25f));
        daynnightCircle.transform.rotation = Quaternion.Euler(0,0,rotation);
        


        if (Time.time - lastrotation > ((dayinmins * 60f) / 1440f))
        {
            time = hours + ":" + (minutes+=1);
            lastrotation = Time.time;
        }
        if(minutes >= 60)
        {
            time = (hours += 1) + ":00";
        }
        if (hours >= 24)
        {
            time = "00:00";
        }

        if (hours == 6)
        {
            onDayStartCallback.Invoke();
        }
        if (hours == 23 && minutes == 59)
        {
            onNightStartCallback.Invoke();
        }
        
    }

}
