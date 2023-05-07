using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType {
    Weapon = 0,
    Coin = 1
};

public class Pickup : MonoBehaviour
{
    public PickupType pickupType;

}
