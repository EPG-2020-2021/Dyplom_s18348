using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManage : MonoBehaviour
{
    GameObject daynnightCircle;
    GameObject directionalLight;
    public float dayinmins = 30f;
    public string time = "14:00";
    float rotation = 0f;
    float lastrotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        print("TimeManagers start");
        daynnightCircle = GameObject.FindGameObjectWithTag("SkyCircle");
        directionalLight = GameObject.Find("Directional Light");
    }


    // Update is called once per frame
    void Update()
    {
        int hours = int.Parse(time.Split(':')[0]);
        int minutes = int.Parse(time.Split(':')[1]);

        
        rotation = ((hours-2) * 15f + (minutes * 0.25f));
        if (daynnightCircle == null)
        {
            Start();
        }
        daynnightCircle.transform.rotation = Quaternion.Euler(0,0,rotation);
        directionalLight.transform.rotation = Quaternion.Euler(0,180-rotation,0);
        


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
    }
}
