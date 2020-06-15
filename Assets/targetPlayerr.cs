using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayerr : MonoBehaviour
{
    public float hp = 100f;
    public void TakeDamagePlayer(float amount)
    {
        hp -= amount;
        if (hp <= 0f)
        {
            Die();
        }
    }
        void Die()
        {
            Destroy(gameObject);
        }
    
}
