using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class Bomb : MonoBehaviour
{
    [SerializeField] int health = 40;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] float explosionForce = 10f;
    [SerializeField] LayerMask explosionLayerMask;
    [SerializeField] float yForce = 10f;
    [SerializeField] int bombDamage = 120;

    public void DoDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        //sound
        //effect

        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayerMask);
        foreach (Collider colliderI in colliders)
        {
            Rigidbody rb = colliderI.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, yForce);
            }

            DestroyableObject destroyable = colliderI.GetComponent<DestroyableObject>();
            if (destroyable != null)
            {
                destroyable.DoDamage(bombDamage);
            }

        }
    
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
