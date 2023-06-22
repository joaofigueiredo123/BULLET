using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    void Awake()
    {
        SpawnPlayer();
    }
    void Start() {
        
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(characters[0], transform.position, characters[0].transform.rotation);
        player.name = player.name.Replace("(Clone)","");
    }
}
