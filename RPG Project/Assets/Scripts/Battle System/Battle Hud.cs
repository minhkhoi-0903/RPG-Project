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

    public void SetHUD(PlayerUnit unitPlayer/*, enemyUnit unitEnemy*/)
    {
        nameText.text = unitPlayer.PlayerName;

        hpSlider.maxValue = unitPlayer.maxMP;
        hpSlider.value = unitPlayer.currentMP;
        hpText.text = unitPlayer.currentMP + "/" + unitPlayer.maxMP;

        mpSlider.maxValue = unitPlayer.maxMP;
        mpSlider.value = unitPlayer.currentMP;
        mpText.text = unitPlayer.currentMP + "/" + unitPlayer.maxMP;
    }

    public void SetHP(float hp)
    {
        hpSlider.value = hp;
    }
}
