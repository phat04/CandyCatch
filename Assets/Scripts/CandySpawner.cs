using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] float maxX;
    [SerializeField] GameObject[] candies;
    [SerializeField] float spawnInterval;

    public static CandySpawner instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartSpawnCandies();
    }

    
    void Update()
    {

    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, candies.Length);
        Vector3 randomPos = new Vector3(Random.Range(-maxX, maxX), transform.position.y, transform.position.z);
        Instantiate(candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void StartSpawnCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawnCandies()
    {
         StopCoroutine("SpawnCandies");
    }
}
