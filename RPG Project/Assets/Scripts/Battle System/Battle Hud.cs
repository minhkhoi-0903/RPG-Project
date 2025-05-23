using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [Header("Player HUD")]
    public TextMeshProUGUI nameText;
    public Slider hpSlider;
    public Slider mpSlider;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;

    public PlayerUnit unitPlayer;

    public void SetHUD(PlayerUnit unitPlayer)
    {
        nameText.text = unitPlayer.PlayerName;

        hpSlider.maxValue = unitPlayer.maxHP;
        hpSlider.value = unitPlayer.currentHP;
        hpText.text = unitPlayer.currentHP + "/" + unitPlayer.maxHP;

        mpSlider.maxValue = unitPlayer.maxMP;
        mpSlider.value = unitPlayer.currentMP;
        mpText.text = unitPlayer.currentMP + "/" + unitPlayer.maxMP;
    }

    public void SetHP(float hp)
    {
        hpSlider.value = hp;
        hpText.text = hp + "/" + unitPlayer.maxHP;
    }
}