using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveIDs : MonoBehaviour
{
    public static SaveIDs instance { get; private set; }
    public int savefileID;
    public int characterID;

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
