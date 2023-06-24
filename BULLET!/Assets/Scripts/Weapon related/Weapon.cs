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
    [SerializeField] float fireRate, initialFireRate, reloadTime, audioClipLength;
    AudioSource weaponSoundSource;
    [SerializeField] AudioClip weaponSoundClip, emptyMagSoundClip, reloadSoundClip;
    bool isReloading = false;
    void Start()
    {
        audioClipLength = weaponSoundClip.length;
        weaponSoundSource = GetComponent<AudioSource>();
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        gameObject.name = weaponName;
        currentBulletCount = magSize;
        playerUICanvas.UpdateBulletCount(magSize, magSize);
    }
    void Update()
    {
        if (!isReloading)
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

                    if (!weaponSoundSource.isPlaying)
                    {
                        weaponSoundSource.PlayOneShot(emptyMagSoundClip, 0.8f);
                    }
                }
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    void Fire()
    {
        StartCoroutine(PlayWeaponSound(weaponSoundClip));
        fireRate = initialFireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = damage;
        currentBulletCount--;
        playerUICanvas.UpdateBulletCount(currentBulletCount, magSize);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        weaponSoundSource.PlayOneShot(reloadSoundClip, 0.3f);
        yield return new WaitForSecondsRealtime(reloadTime);
        currentBulletCount = magSize;
        playerUICanvas.UpdateBulletCount(currentBulletCount, magSize);
        isReloading = false;
    }

    IEnumerator PlayWeaponSound(AudioClip weaponSound)
    {
        weaponSoundSource.PlayOneShot(weaponSound, 0.85f);
        yield return new WaitForSecondsRealtime(weaponSound.length);
    }

}
