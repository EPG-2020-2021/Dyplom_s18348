using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    private Transform target;

    public float smoothSpeed;
    public Vector2 pos;

    public Vector2 limitaionMin;
    public Vector2 limitaionMax;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(pos.x, pos.y, - target.position.z + transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(
            Mathf.Clamp(smoothedPosition.x, limitaionMin.x, limitaionMax.x),
            Mathf.Clamp(smoothedPosition.y, limitaionMin.y, limitaionMax.y),
                        smoothedPosition.z);   
    }
}
