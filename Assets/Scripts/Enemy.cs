using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public void Die(Transform bullet, float bulletForce)
    {
        SetRagdoll(true);
        Collider[] colliders = Physics.OverlapSphere(bullet.position, 0.3f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.AddExplosionForce(bulletForce, bullet.position, 0.1f, 0, ForceMode.Impulse);
             };
        }
    }
}
