using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] float spawnCooldown;
    [SerializeField] Transform spawnPoint;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        Instantiate(zombiePrefab, spawnPoint.position, zombiePrefab.transform.rotation);
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemy());
    }
}
