using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour
{
    public Material material;

    private MeshRenderer renderer;


    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();

        renderer.material = material;
    }

    private void FixedUpdate()
    {
        var positionChange = new Vector3(
            transform.position.x - (int)transform.position.x,
            transform.position.y - (int)transform.position.y,
            transform.position.z - (int)transform.position.z
            );
        var scaleChange = new Vector3(
            transform.lossyScale.x - (int)transform.lossyScale.x,
            transform.lossyScale.y - (int)transform.lossyScale.y,
            transform.lossyScale.z - (int)transform.lossyScale.z
            );

        var x = 0f;
        var z = 0f;

        x += (int)transform.lossyScale.x % 2 == 0 ?
        -positionChange.x - scaleChange.x / 2 : -positionChange.x + ((10 - scaleChange.x * 10) * 0.05f);

        z += (int)transform.lossyScale.y % 2 == 0 ?
        -positionChange.z - scaleChange.y / 2 : -positionChange.z + ((10 - scaleChange.y * 10) * 0.05f);

        material.mainTextureOffset = new Vector2(x, z);
        material.mainTextureScale = new Vector2(transform.lossyScale.x, transform.lossyScale.y);
    }
}