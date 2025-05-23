using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float currentMP;
    public float maxMP;
    public float physicalDamage;
    public float magicalDamage;

    [Header("Base Unit")]
    public string PlayerName;
    [SerializeField] float Vigor;
    [SerializeField] float Strength;
    [SerializeField] float Dexterity;
    [SerializeField] float Mind;
    [SerializeField] float Intelligence;
    
    
    void Awake()
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

    public void takeDamage()
    {}
}
