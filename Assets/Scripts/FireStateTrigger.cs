using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStateTrigger : MonoBehaviour
{
    [SerializeField] private MeshCollider mesh;
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] private float detectRadius = 15f;
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(other.transform.position, detectRadius, enemylayer);
        if (colliders.Length > 0)
        {
            Player player = other?.GetComponent<Player>();
            if (player != null)
            {
                player.ShootState();
                mesh.enabled = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
