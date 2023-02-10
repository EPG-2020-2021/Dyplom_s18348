using System;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed = 0.06f;

    public Vector2 pos = new Vector2(0f, 1f);

    public Vector2 limitaionMin = new Vector2(-1000f, -1000f);

    public Vector2 limitaionMax = new Vector2(1000f, 1000f);

    public SmoothCamera()
    {
    }

    private void FixedUpdate()
    {
        Vector3 vector3 = this.target.position + new Vector3(this.pos.x, this.pos.y, -this.target.position.z + base.transform.position.z);
        Vector3 vector31 = Vector3.Lerp(base.transform.position, vector3, this.smoothSpeed);
        base.transform.position = new Vector3(Mathf.Clamp(vector31.x, this.limitaionMin.x, this.limitaionMax.x), Mathf.Clamp(vector31.y, this.limitaionMin.y, this.limitaionMax.y), vector31.z);
    }

    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}