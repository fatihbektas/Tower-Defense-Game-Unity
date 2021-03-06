using UnityEngine;

public class Turret : MonoBehaviour
{
    #region Fields

    [Header("General")] public float range = 15f;

    [Header("Use Bullets (default)")] public float fireRate = 1f;
    public GameObject bulletPrefab;
    private float _fireCountdown;

    [Header("Use Laser")] public bool useLaser = false;
    public int damageOverTime = 30;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public float slowPct = .5f;

    [Header("Unity Setup Fields")] public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

    private Transform _target;
    private Enemy _targetEnemy;

    #endregion

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
        {
            if (!useLaser) return;
            if (!lineRenderer.enabled) return;
            lineRenderer.enabled = false;
            impactEffect.Stop();

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
       _targetEnemy.TakeDamage( (damageOverTime * Time.deltaTime));
       _targetEnemy.Slow(slowPct);
       
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }

        var targetPosition = _target.position;
        var firePointPosition = firePoint.position;
        var impactEffectTransform = impactEffect.transform;

        lineRenderer.SetPosition(0, firePointPosition);
        lineRenderer.SetPosition(1, targetPosition);

        var dir = firePointPosition - targetPosition;

        impactEffectTransform.position = targetPosition;

        impactEffectTransform.rotation = Quaternion.LookRotation(dir);
    }

    private void LockOnTarget()
    {
        var dir = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(dir);
        var rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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

            if (!(distanceToEnemy < shortestDistance)) continue;
            shortestDistance = distanceToEnemy;
            nearestEnemy = enemy;
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
            _targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
        }
    }
}