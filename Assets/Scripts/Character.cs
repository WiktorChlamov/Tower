using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Animator animator = null;
    protected Rigidbody[] parts;
    protected Collider[] colliders;
    void Start()
    {
        parts = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        SetRagdoll(false);
    }
    protected void SetRagdoll(bool state)
    {
        animator.enabled = !state;
        foreach (Rigidbody rb in parts)
        {
            rb.isKinematic = !state;
        }
    /*foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }*/
      //  capsuleCollider.enabled = true;
    }
}
