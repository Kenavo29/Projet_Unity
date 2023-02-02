using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform standartPrefab;

    [SerializeField]
    private Transform HeavyPrefab;

    [SerializeField]
    private Transform FastPrefab;

    [SerializeField]
    private Transform spawnPoint;

    
    public double timeBetweenWaves = 5f;

    private double countdown = 5f;

    [SerializeField]
    private Text waveCountdownTimer;

    public static int nbVagues = 10;

    public int waveIndex = 0;

    public int[] ennemiesStandarts = { 1, 2, 3, 5, 7, 10, 13, 15, 17, 20 };
    public int[] ennemiesHeavy = { 0, 0, 1, 0, 3, 0, 0, 4, 4, 0 };
    public int[] ennemiesFast = { 0, 2, 0, 4, 0, 0, 8, 0, 0, 10 };

   
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp((float)countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        int nbEnnStdt = ennemiesStandarts[waveIndex];
        int nbEnnHvy = ennemiesHeavy[waveIndex];
        int nbEnnFast = ennemiesFast[waveIndex];

        timeBetweenWaves = (nbEnnStdt + nbEnnHvy + nbEnnFast)*2;
        while (nbEnnStdt > 0 || nbEnnHvy > 0 | nbEnnFast > 0)
        {
            if(nbEnnStdt > 0){
                SpawnEnemyStandart();
                yield return new WaitForSeconds(0.25f);
                nbEnnStdt--;
            }
            if (nbEnnHvy > 0){
                SpawnEnemyHeavy();
                yield return new WaitForSeconds(0.25f);
                nbEnnHvy--;
            }
            if (nbEnnFast > 0){
                SpawnEnemyFast();
                yield return new WaitForSeconds(0.25f);
                nbEnnFast--;

            }
        }
        waveIndex++;

    }

    void SpawnEnemyStandart()
    {
        Instantiate(standartPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnEnemyHeavy()
    {
        Instantiate(HeavyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    public void SpawnEnemyFast()
    {
        Instantiate(FastPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}