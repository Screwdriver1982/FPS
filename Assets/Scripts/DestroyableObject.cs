using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField] GameObject destroyedObject;
    [SerializeField] int health = 100;

    public void DoDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyedObject, transform.position, transform.rotation);
        }
    }

}
