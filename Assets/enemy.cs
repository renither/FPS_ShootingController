using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float timeShots;
    public float startTimeShots = 2000;
    public float speed;
    public float stopDist;
    public float startDist;
    //ParticleSystem muzzleFlash;
    public float damage = 10f;
    public float range = 15f;
    public Transform gun;
    public float hp;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeShots = startTimeShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stopDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        /*
        else if ((Vector3.Distance(transform.position, player.position) < stopDist) && (Vector3.Distance(transform.position, player.position) > startDist))
        {
            //transform.position = this.transform.position;

        }*/
        else if (Vector3.Distance(transform.position, player.position) < startDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        transform.LookAt(player);
        transform.Rotate(0, 180, 0);
        if (timeShots <= 0)
        {
            Shoot();
            timeShots = startTimeShots;
            Debug.Log(" shoot Time " + timeShots);
        }
        else
        {
            timeShots -= Time.deltaTime;
        }
        void Shoot()
        {
            //muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit, range))
            {
                Debug.Log("Enemy " + hit.transform.name);
                targetPlayerr target = hit.transform.GetComponent<targetPlayerr>();
                if (target != null)
                {
                    target.TakeDamagePlayer(damage);
                }
            }
        }
    }
}
