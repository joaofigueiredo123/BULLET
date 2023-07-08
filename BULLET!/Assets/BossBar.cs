using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBar : MonoBehaviour
{
    [SerializeField] GameObject maxHealthBar, currentHealthBar;
    int bossMaxHealth, bossCurrentHealth;
    float scale;
    Enemy boss;
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<Enemy>();
        bossMaxHealth = boss.maxHealth;
        bossCurrentHealth = bossMaxHealth;
    }

    void Update()
    {
        if (!boss.isDead)
        {
            bossCurrentHealth = boss.health;
            scale = ((float)bossCurrentHealth) / ((float)bossMaxHealth);
            currentHealthBar.transform.localScale = new Vector3(scale, currentHealthBar.transform.localScale.y, currentHealthBar.transform.localScale.z);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
