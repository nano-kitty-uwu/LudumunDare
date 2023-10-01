using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyScript : MonoBehaviour
{
    public float hp;

    public UnityEvent EnemyDeath;
	public void takeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        EnemyDeath?.Invoke();
        Destroy(gameObject);
    }
}
