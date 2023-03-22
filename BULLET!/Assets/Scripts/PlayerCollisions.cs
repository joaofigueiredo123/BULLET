using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public bool isDead = false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Trap"){
            Destroy(gameObject);
            isDead = true;  
        } 
    }
}
