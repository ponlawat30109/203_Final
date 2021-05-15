using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCan : MonoBehaviour
{
    [SerializeField] float radius = 2f;
    [SerializeField] float force = 10f;

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObj in colliders)
        {
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Explode();
            Destroy(other.gameObject, 1f);
        }

        // Destroy(other.gameObject, 1f);
    }
}
