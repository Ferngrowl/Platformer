using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2Dplatformer : MonoBehaviour
{
    public Transform target; //what the camera is following
    public float smoothing; //dampening effect

    Vector3 offset;

    float lowY;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

        lowY = -5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing*Time.deltaTime);

        if (transform.position.y < lowY )
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
