using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")] public float range = 15f;
    public float fireRate = 1f;

    [Header("Unity Setup Fields")] public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private float _fireCountdown;
    private Transform _target;


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (_target == null) return;

        var dir = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(dir);
        var rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_fireCountdown <= 0f)
        {
            Shoot();
            _fireCountdown = 1f / fireRate;
        }

        _fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot()
    {
        var bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null) 
            bullet.Seek(_target);
    }

    private void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
            _target = nearestEnemy.transform;
        else
            _target = null;
    }
}