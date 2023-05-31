using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Weapon = 0,
    Coin = 1
};

public class Pickup : MonoBehaviour
{
    public PickupType pickupType;
    public AudioClip pickupSound;
    public AudioSource playerSoundSource;

    private void Start()
    {
        playerSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }
    public void PlayPickupSound()
    {
        playerSoundSource.PlayOneShot(pickupSound, 1.0f);
    }
}
