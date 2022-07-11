using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;//player
    public float smoothing; 
    public Vector2 minPosition, maxPosition;

    private void Start()
    {
        transform.position = new Vector3( target.position.x,
            target.position.y,-10f);
    }
    private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                target.position.y,
                transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x,
                minPosition.x,
                maxPosition.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y,
                minPosition.y,
                maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,
                targetPosition,
                smoothing);
        }
    }

}
