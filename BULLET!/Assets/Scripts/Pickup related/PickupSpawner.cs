using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject pickup;
    [SerializeField] float spawnCooldown;
    void Start()
    {
        StartCoroutine(SpawnPickup());
    }
    IEnumerator SpawnPickup()
    {
        Instantiate(pickup, pickup.transform.position, pickup.transform.rotation);
        yield return new WaitForSecondsRealtime(spawnCooldown);
        StartCoroutine(SpawnPickup());
    }
}
