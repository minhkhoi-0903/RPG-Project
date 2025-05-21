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

    public void SetHUD(PlayerUnit unitPlayer, enemyUnit unitEnemy)
    {
        nameText.text = unitPlayer.PlayerName;

        hpSlider.maxValue = unitPlayer.maxHP;
        hpSlider.value = unitPlayer.currentHP;
        hpText.text = unitPlayer.currentMP + "/" + unitPlayer.maxHP;
    }
}
