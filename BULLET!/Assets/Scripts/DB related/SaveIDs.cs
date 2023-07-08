using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveIDs : MonoBehaviour
{
    public static SaveIDs instance { get; private set; }
    public int savefileID;
    public int characterID;
    public int level;
    public int upgrade1_level, upgrade2_level, upgrade3_level, upgrade4_level;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

}
