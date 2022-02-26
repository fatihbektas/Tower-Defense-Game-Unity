using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;
    public TMP_Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float _countdown = 2f;
    private int _waveIndex;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(_countdown).ToString(CultureInfo.CurrentCulture);
    }

    private IEnumerator SpawnWave()
    {
        _waveIndex++;

        for (var i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}