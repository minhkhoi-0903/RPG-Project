using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST, ESCAPE}

public class Battlesystem : MonoBehaviour
{
    public BattleState state;

    public PlayerUnit playerUnit;

    [Header ("Enemy Setup")]
    public TextMeshProUGUI enemyName;
    enemyUnit Unit;
    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject enemySampleGO = Instantiate(enemyPrefab, enemyBattleStation);
        Unit = enemySampleGO.GetComponent<enemyUnit>();

        enemyName.text = Unit.unitName;
    }
    
}
