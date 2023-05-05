using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int fireForce, magSize;
    int currentBulletCount;
    [SerializeField] float fireRate, initialFireRate;
    void Start()
    {
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        currentBulletCount = magSize;
    }
    void Update()
    {
        if (fireRate <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (currentBulletCount > 0)
                {
                    Fire();
                }
            }
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        currentBulletCount--;
        fireRate = initialFireRate;
        // playerUICanvas.UpdateBulletCount(magSize);
    }
}
