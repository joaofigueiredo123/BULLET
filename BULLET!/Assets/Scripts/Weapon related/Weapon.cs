using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    public string weaponName;
    [SerializeField] int fireForce, magSize, damage;
    int currentBulletCount;
    [SerializeField] float fireRate, initialFireRate, reloadTime, audioClipLength;
    AudioSource weaponSoundSource;
    [SerializeField] AudioClip weaponSoundClip, emptyMagSoundClip, reloadSoundClip;
    bool isReloading = false;
    public int damageMultiplier, damageUpgrade;
    public float firerateMultiplier, firerateUpgrade;
    void Start()
    {
        damageMultiplier = 1;
        firerateMultiplier = 1.0f;
        audioClipLength = weaponSoundClip.length;
        weaponSoundSource = GetComponent<AudioSource>();
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        gameObject.name = weaponName;
        currentBulletCount = magSize;
        playerUICanvas.UpdateBulletCount(magSize, magSize);
        damageUpgrade = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade2_level;
        firerateUpgrade = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().upgrade4_level;
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

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }

    }

    void Fire()
    {
        StartCoroutine(PlayWeaponSound(weaponSoundClip));
        fireRate = (initialFireRate / (1 + (firerateUpgrade * 0.05f))) / firerateMultiplier;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().damage = (damage + (damageUpgrade * 1)) * damageMultiplier;
        currentBulletCount--;
        playerUICanvas.UpdateBulletCount(currentBulletCount, magSize);

        HandleGameData.UpdateShotStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);
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
