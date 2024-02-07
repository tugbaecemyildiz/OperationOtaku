using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ScoreManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }

}//class
