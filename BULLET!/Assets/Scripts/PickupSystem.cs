using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<WeaponPickup>(out WeaponPickup weaponPickupScript))
        {
            // if(weaponPickupScript.weaponType == "Ranged"){
            //     // if(weaponPickupScript.weaponName == ""){

                    
            //     // }
            //     Destroy(other.gameObject);
            //     return;
            // }
            
            // if(weaponPickupScript.weaponType == "Melee"){

            //     Destroy(other.gameObject);
            //     return;
            // }

        }
    }
}
