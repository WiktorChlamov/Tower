using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] CameraFollow cameraFollow;
    [SerializeField] GameController mouseController;
    public void ShootState()
    {
        mouseController.NavMesh.isStopped = true;
        animator.Play("Pistol Idle");
        Invoke(nameof(OffAnimator), 1f);
        cameraFollow.FireState();
        mouseController.FireState();
    }
    private void OffAnimator()
    {
        animator.enabled = false;
    }

}
