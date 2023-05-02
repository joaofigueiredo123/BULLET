using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int fireForce;
    public string weaponName;
    public int magSize, currentBulletCount;
    public float fireRate;
    [SerializeField] float initialFireRate;
    void Start()
    {
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
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

        gameObject.name = weaponName;
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
        currentBulletCount--;
        fireRate = initialFireRate;
        playerUICanvas.UpdateBulletCount(currentBulletCount, magSize);
    }
}
