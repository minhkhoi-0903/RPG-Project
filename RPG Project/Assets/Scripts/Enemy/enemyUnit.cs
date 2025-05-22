using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyUnit : MonoBehaviour
{
    public string unitName;
    public int Damage;
    public float maxHP;
    public float currentHP;

    void Start()
    {      
        currentHP= maxHP;
    }

    public bool takeDamage(float dmg)
    {
        float delayDMG = Random.Range(-5, 5);
        currentHP -= dmg - delayDMG;
        Debug.Log("take DMG");

        if (currentHP <=0)
            return true;
        else
            return false;
    }
}
