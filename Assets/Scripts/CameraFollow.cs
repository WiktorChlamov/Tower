using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smooth = 0.125f, rotatingSpeed = 5f;
    public Vector3 cameraRotateOffset;
    public bool runState = true;
    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion camAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotatingSpeed, Vector3.up);
            cameraRotateOffset = camAngle * cameraRotateOffset;
            if (!runState)
            {
            player.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotatingSpeed);
             }
        }
        Vector3 positionOffset = player.position + cameraRotateOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionOffset, smooth);
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }
    public void FireState()
    {
        runState = false;
        cameraRotateOffset = new Vector3(0, 2, -5);
    }
}
