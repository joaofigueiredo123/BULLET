using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    PlayerUICanvasHandler playerUICanvas;
    PlayerMovement playerMovementScript;
    Weapon weaponReferenceScript;
    [SerializeField] private GameObject ak47;
    [SerializeField] private GameObject p90;
    [SerializeField] private GameObject hand;
    GameObject weaponPickedUp;
    [SerializeField] string currentWeapon = "";

    private void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
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

                SetWeapon();
                playerUICanvas.EnableWeaponAmmoUI(true);
                Destroy(other.gameObject);
                return;
            }

            if ((int)pickup.pickupType == 1)
            {
                playerUICanvas.UpdateCoinCount(1);

                HandleGameData.UpdateCoinStat(GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID, 1);

                Destroy(other.gameObject);
                return;
            }

            if ((int)pickup.pickupType == 2)
            {
                if (currentWeapon == "AK47" || currentWeapon == "P90")
                {
                    weaponReferenceScript = GameObject.Find(currentWeapon).GetComponent<Weapon>();
                    SetPowerup();
                }

                Destroy(other.gameObject);
                return;
            }

        }
    }

    void SetWeapon()
    {
        int randomWeaponIndex = Random.Range(0, 2);

        switch (randomWeaponIndex)
        {
            case 0:
                currentWeapon = "AK47";
                GenerateWeapon(ak47);
                break;

            case 1:
                currentWeapon = "P90";
                GenerateWeapon(p90);
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

    void SetPowerup()
    {
        int randomPowerupIndex = Random.Range(0, 3);

        playerUICanvas.EnablePowerupUI(randomPowerupIndex, true);

        switch (randomPowerupIndex)
        {
            case 0:
                StartCoroutine(FireratePowerup(15.0f, randomPowerupIndex));
                break;
            case 1:
                StartCoroutine(SpeedPowerup(15.0f, randomPowerupIndex));
                break;
            case 2:
                StartCoroutine(DamagePowerup(15.0f, randomPowerupIndex));
                break;
        }

    }

    IEnumerator FireratePowerup(float duration, int index)
    {
        weaponReferenceScript.firerateMultiplier = 1.5f;
        yield return new WaitForSecondsRealtime(duration);
        weaponReferenceScript.firerateMultiplier = 1.0f;
        playerUICanvas.EnablePowerupUI(index, false);
    }
    IEnumerator SpeedPowerup(float duration, int index)
    {
        playerMovementScript.speedMultiplier = 1.70f;
        yield return new WaitForSecondsRealtime(duration);
        playerMovementScript.speedMultiplier = 1.0f;
        playerUICanvas.EnablePowerupUI(index, false);
    }

    IEnumerator DamagePowerup(float duration, int index)
    {
        weaponReferenceScript.damageMultiplier = 2;
        yield return new WaitForSecondsRealtime(duration);
        weaponReferenceScript.damageMultiplier = 1;
        playerUICanvas.EnablePowerupUI(index, false);
    }


}
