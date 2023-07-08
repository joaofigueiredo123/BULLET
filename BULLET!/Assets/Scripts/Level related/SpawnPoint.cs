using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characters;
    void Awake()
    {
        int index = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().characterID - 1;
        SpawnPlayer(index);
    }
    void Start()
    {
    }

    void SpawnPlayer(int index)
    {
        GameObject player = Instantiate(characters[index], transform.position, characters[index].transform.rotation);
        player.name = player.name.Replace(" " + (index + 1) + "(Clone)", "");
    }
}
