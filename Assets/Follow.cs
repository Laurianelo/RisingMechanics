using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject target;

    public float smoothTime = 0.3f;
    public float yOffset;

    private float offsetCamZ = -10f;
    private Vector2 velocity = Vector2.zero;
   

    private void Update()
    {
        Vector2 targetPos = target.transform.TransformPoint(new Vector3(0, yOffset));

        if(targetPos.y < transform.position.y)
        {
            return;
        }

        targetPos = new Vector2(0, targetPos.y);
        transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, offsetCamZ);
    }
}
