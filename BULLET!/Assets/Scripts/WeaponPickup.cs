using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
    Melee,
    Ranged
};

public enum WeaponName {
    AK47,
    USP_S,
    M4,
    SPAS_12
};
public class WeaponPickup : MonoBehaviour
{
    public WeaponType weaponType;
    public WeaponName weaponName;
    public int magazineSize;
    public int pickupBullets;
    void Update()
    {
        
    }
}
