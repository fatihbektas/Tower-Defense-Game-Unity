using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int value = 50;

    private Transform _target;
    private int _wavePointIndex;

    private void Start()
    {
        _target = Waypoints.Points[0];
    }

    private void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= .4f)
            GetNextWaypoint();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Debug.Log("health 0");
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    private void GetNextWaypoint()
    {
        if (_wavePointIndex >= Waypoints.Points.Length - 1)
        {
            EndPath();     
            return;
        }
        _wavePointIndex++;
        _target = Waypoints.Points[_wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject); 
    }
}