using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    [SerializeField] private GameObject ak47;
    [SerializeField] private GameObject p90;
    [SerializeField] private GameObject awp;
    [SerializeField] private GameObject hand;
    GameObject weaponPickedUp;

    private void Start()
    {
        playerUICanvas = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Pickup>(out Pickup pickup))
        {
            pickup.PlayPickupSound();

            if ((int)pickup.pickupType == 0)
            {

                if (GameObject.Find("AK47"))
                {
                    Debug.Log("existe ak47 na cena.");
                    Destroy(GameObject.Find("AK47"));
                }

                if (GameObject.Find("P90"))
                {
                    Debug.Log("existe p90 na cena.");
                    Destroy(GameObject.Find("P90"));
                }

                if (GameObject.Find("AWP"))
                {
                    Debug.Log("existe awp na cena.");
                    Destroy(GameObject.Find("AWP"));
                }

                SetWeapon();
                playerUICanvas.EnableWeaponAmmoUI(true);

                Destroy(other.gameObject);
                return;
            }

            if ((int)pickup.pickupType == 1)
            {
                playerUICanvas.UpdateCoinCount(1);

                Destroy(other.gameObject);
                return;
            }

        }
    }

    void SetWeapon()
    {
        int randomWeaponIndex = Random.Range(0, 3);

        switch (randomWeaponIndex)
        {
            case 0:
                GenerateWeapon(ak47);
                break;

            case 1:
                GenerateWeapon(p90);
                break;

            case 2:
                GenerateWeapon(awp);
                break;

            default:
                break;
        }
    }
    void GenerateWeapon(GameObject weapon)
    {
        weaponPickedUp = Instantiate(weapon, hand.transform.position, hand.transform.rotation);
        weaponPickedUp.transform.parent = hand.transform;
    }
}
