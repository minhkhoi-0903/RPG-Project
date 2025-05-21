using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [Header("Base Unit")]
    [SerializeField] string PlayerName;
    [SerializeField] float Vigor;
    [SerializeField] float Strength;
    [SerializeField] float Dexterity;
    [SerializeField] float Mind;
    [SerializeField] float Intelligence;

    private float currentHP;
    private float maxHP;
    private float currentMP;
    private float maxMP;
    private float physicalDamage;
    private float magicalDamage;
    
    
    void Start()
    {
        maxHP = 100 + 10*Vigor;
        currentHP = maxHP;

        maxMP = 100 + 10*Intelligence + 5*Mind;
        currentMP = maxMP;

        physicalDamage = 5*Strength;

        magicalDamage = 5*Mind;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
