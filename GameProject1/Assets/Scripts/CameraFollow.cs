using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;

    
    private void FixedUpdate()
    {
        Follow();
    }

    // Update is called once per frame
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPossition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
    }
}
 