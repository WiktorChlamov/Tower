using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody rb;
   [SerializeField] private BulletForce bulletForce;
   [SerializeField] private float speed = 10;
    private void Start()
    {   
        Destroy(gameObject, 5);
    }
    void FixedUpdate()
    {
        rb.velocity= transform.up*speed;
    }
    private void OnCollisionEnter(Collision collision)
    {   
        if(collision.gameObject.GetComponent<BulletMovement>())
        {
            Debug.LogWarning("too much fire rate!");
            return;
        }
        Enemy enemy = collision.gameObject?.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            enemy.Die(transform, bulletForce.bulletForce);
        }
        Destroy(gameObject);
    }
}
