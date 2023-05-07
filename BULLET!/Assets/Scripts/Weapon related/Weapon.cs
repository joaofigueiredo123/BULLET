using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] string weaponName;
    [SerializeField] int fireForce, magSize, damage;
    int currentBulletCount;
    [SerializeField] float fireRate, initialFireRate;
    AudioSource weaponSoundSource;
    [SerializeField] AudioClip weaponSoundClip, emptyMagSoundClip;
    void Start()
    {
        weaponSoundSource = GetComponent<AudioSource>();
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        gameObject.name = weaponName;
        currentBulletCount = magSize;
        playerUICanvas.UpdateBulletCount(magSize, magSize);
    }
    void Update()
    {
        if (fireRate <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (currentBulletCount > 0)
                {
                    Fire();
                    return;
                }

                if (weaponSoundSource.isPlaying)
                {
                    weaponSoundSource.Stop();
                }

                weaponSoundSource.PlayOneShot(emptyMagSoundClip);
            }
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
    }

    void Fire()
    {
        if (weaponSoundSource.isPlaying)
        {
            weaponSoundSource.Stop();
        }
        weaponSoundSource.PlayOneShot(weaponSoundClip);
        fireRate = initialFireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = damage;
        currentBulletCount--;
        playerUICanvas.UpdateBulletCount(currentBulletCount, magSize);
    }
}
