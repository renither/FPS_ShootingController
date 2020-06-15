using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float hp = 50f;
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if(hp<=0f)
        {
            Die();
        }
        void Die()
            {
            Destroy(gameObject);
        }
    }
}
