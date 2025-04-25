using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0f, 10f, -5f);

    [SerializeField]
    private float followSpeed = 5f;

    void LateUpdate(){
        if(target == null)
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 followedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        this.transform.position = followedPosition;

        this.transform.LookAt(target);
    }
}
