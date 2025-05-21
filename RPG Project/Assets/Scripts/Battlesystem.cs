using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST}

public class Battlesystem : MonoBehaviour
{
    public BattleState state;

    void START()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        
    }
    
}
