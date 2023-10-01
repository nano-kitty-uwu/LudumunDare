using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyScript : MonoBehaviour
{
    public Transform movePoint;
    public float hp;
    public int titlesToMove = 1;
    public bool canItMove = true;

    public UnityEvent TakeDamage;
    public UnityEvent EnemyDeath;
	public void takeDamage()
    {
        hp -= 1;
        TakeDamage?.Invoke();
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

    public void Move()
    {
        if (canItMove)
        {
            for (int i = 1; i <= titlesToMove; i++)
            {

                transform.position = movePoint.position;
            }
            //CharacterMoved?.Invoke();

        }
    }
}
