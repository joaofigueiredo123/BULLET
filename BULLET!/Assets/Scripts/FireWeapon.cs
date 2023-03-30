using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int fireForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * fireForce, ForceMode2D.Impulse);
    }
}
