using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    Weapon weapon;
    private void Start()
    {
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
        {
            if ((int)pickup.pickupType == 0)
            {
                UpdateWeapon();

                Destroy(other.gameObject);
                return;
            }

            if ((int)pickup.pickupType == 1)
            {
                UpdateCoins();

                Destroy(other.gameObject);
                return;
            }

        }
    }

    void UpdateWeapon()
    {
        int randomWeaponIndex = Random.Range(0, 3);

        switch (randomWeaponIndex)
        {
            case 0:
                SetWeapon("AK47", 30, 0.2f);
                break;

            case 1:
                SetWeapon("P90", 50, 0.07f);
                break;

            case 2:
                SetWeapon("KATANA", 0, 1);
                break;

            default:
                break;
        }
    }
    void SetWeapon(string weaponName, int magSize, float fireRate)
    {
        Debug.Log("picked up " + weaponName);
        weapon.weaponName = weaponName;
        weapon.magSize = magSize;
        weapon.currentBulletCount = magSize;
        weapon.fireRate = fireRate;
        playerUICanvas.UpdateBulletCount(magSize,magSize);
    }

    void UpdateCoins()
    {
        playerUICanvas.UpdateCoinCount();
    }

}
