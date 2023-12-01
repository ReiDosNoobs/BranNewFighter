using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject homiPrefab;
    [SerializeField]
    private GameObject muiePrefab;
    [SerializeField]
    private GameObject carecaPrefab;

    private float homiInterval = 7f;
    private float muieInterval = 7f;
    private float carecaInterval = 14f;

    private float initialWaveDuration = 0f;
    private float waveDuration;
    private float initialWaveInterval = 5f;
    private float waveInterval;
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(7f);

        waveDuration = initialWaveDuration + waveCount;
        waveInterval = initialWaveInterval + waveCount * 1.5f;

        while (waveDuration > 0)
        {
            SpawnEnemy(homiPrefab);
            SpawnEnemy(muiePrefab);
            SpawnEnemy(carecaPrefab);

            yield return new WaitForSeconds(1f);

            waveDuration -= 1f;
        }

        homiInterval -= 0.2f;
        muieInterval -= 0.2f;
        carecaInterval -= 0.2f;

        waveCount++;

        yield return new WaitForSeconds(waveInterval);

        StartCoroutine(SpawnWave());
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(Random.Range(-6.0f, 65.0f), Random.Range(-5.0f, -1.0f), 0), Quaternion.identity);
    }

}
