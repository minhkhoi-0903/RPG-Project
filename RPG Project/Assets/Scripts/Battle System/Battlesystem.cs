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

    public BattleHud playerHUD;

    [Header ("Enemy Setup")]
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI enemyDMG_Text;
    enemyUnit Unit;
    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        enemyDMG_Text.gameObject.SetActive(false);
    }

    IEnumerator SetupBattle()
    {
        GameObject enemySampleGO = Instantiate(enemyPrefab, enemyBattleStation);
        Unit = enemySampleGO.GetComponent<enemyUnit>();

        enemyName.text = Unit.unitName;

        playerHUD.SetHUD(playerUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    void playerTurn()
    {

    }

    IEnumerator playerAttack()
    {
        bool isDead = Unit.takeDamage(playerUnit.physicalDamage); 
        enemyDMG_Text.gameObject.SetActive(true);
        enemyDMG_Text.text = "-" + playerUnit.physicalDamage;

        yield return new WaitForSeconds(2f); 

        enemyDMG_Text.gameObject.SetActive(false);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        } 
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.takeDamage(Unit.Damage);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        } else{
            state = BattleState.PLAYERTURN;
            playerTurn();
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(playerAttack());
    }

    public void OnEscapeButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        Escape();
    }

    public void EndBattle()
    {
        if (state == BattleState.WIN)
        {
            //win
            Debug.Log("you win");
        }else if (state == BattleState.LOST)
        {
            //lose
            Debug.Log("you lose");
        }
    }

    public void Escape()
    {
        state = BattleState.ESCAPE;
        Debug.Log("Escape!");
    }
}
