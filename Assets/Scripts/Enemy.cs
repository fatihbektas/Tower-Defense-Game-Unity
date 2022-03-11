using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public int worth = 50;
    [HideInInspector] public float speed;
    public float startSpeed = 10f;
    
    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += worth;
        Destroy(gameObject);
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}