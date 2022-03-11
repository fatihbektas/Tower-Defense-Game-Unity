using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemy;
    private Transform _target;
    private int _wavePointIndex;
    
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = Waypoints.Points[0];
    }

    private void Update()
    {
        var dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= .4f)
        {
            GetNextWaypoint();
        }
        _enemy.speed = _enemy.startSpeed;
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