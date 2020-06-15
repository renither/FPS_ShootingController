using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public ParticleSystem muzzleFlash;
    public Camera fpscam;
    public float damage = 10f;
    public float range = 1000f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        void Shoot()
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit,range))
            {
                Debug.Log(hit.transform.name);
                target target = hit.transform.GetComponent<target>();
                if(target!=null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
