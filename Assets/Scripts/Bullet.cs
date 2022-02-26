using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    public GameObject impactEffect;
    private Transform _target;

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var dir = _target.position - transform.position;
        var distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        var effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }

    public void Seek(Transform target)
    {
        _target = target;
    }
}