using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] AudioClip levelMusic;
    AudioSource levelAudioSource;
    GameObject playerReference;
    PlayerMovement playerMovementScriptReference;
    public Weapon weaponScriptReference;
    private void Awake()
    {
        int saveID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID;
        GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade1_level = UpgradesManager.GetUpgradeLevel(saveID, 1);
        GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade2_level = UpgradesManager.GetUpgradeLevel(saveID, 2);
        GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade3_level = UpgradesManager.GetUpgradeLevel(saveID, 3);
        GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade4_level = UpgradesManager.GetUpgradeLevel(saveID, 4);

        playerMovementScriptReference = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    void Start()
    {
        playerReference = GameObject.Find("Player");
        
        playerMovementScriptReference.speedUpgrade = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade3_level;

        if (GameObject.Find("MenuMusic"))
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Pause();
        }
        levelAudioSource = GetComponent<AudioSource>();
        levelAudioSource.PlayOneShot(levelMusic, 0.4f);
    }

    void Update()
    {
        if (playerReference.GetComponent<Player>().isDead)
        {
            levelAudioSource.Stop();
        }
    }
}
