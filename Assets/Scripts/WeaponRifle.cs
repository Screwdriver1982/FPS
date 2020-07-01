using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 30;
    [SerializeField] LayerMask damageLayerMask;
    [SerializeField] ParticleSystem flashEffect;

    [Header("Impact")]
    [SerializeField] float impactForce = 10f;
    [SerializeField] GameObject impactEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flashEffect.Play();
            //Debug.DrawRay(mainCamera.position, mainCamera.forward*range , Color.red, 10f);
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hit, range, damageLayerMask))
            {
                //TODO use POOL
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce((hit.point - mainCamera.position).normalized * impactForce);
                }

                DestroyableObject destroyable = hit.collider.GetComponent<DestroyableObject>();
                if (destroyable != null)
                {
                    destroyable.DoDamage(damage);
                }

                Bomb bomb = hit.collider.GetComponent<Bomb>();
                
                if (bomb !=null)
                {
                    bomb.DoDamage(damage);
                }

            }


        }
    }
}
