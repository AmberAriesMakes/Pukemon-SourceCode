using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy }

public class BattleConductor : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Player enemy;
    [SerializeField] StatusHud enemyHud;
    [SerializeField] StatusHud playerHud;
   [SerializeField] Dialogue dialogBox;
    public event Action<bool> OnBattleOver;
    BattleState state;
    
    int currAction;
    int currMove;
    
    
    public void StartBattle()
    {
        
        StartCoroutine(Battleinit());
    }
   

    public IEnumerator Battleinit()
    {
       
        player.Setup();
        enemy.Setup();
        playerHud.SetData(player.Pukemon);
        enemyHud.SetData(enemy.Pukemon);
        dialogBox.SetMoveNames(player.Pukemon.Moves);
        yield return dialogBox.TypeDialog($"A wild {enemy.Pukemon.Base.Name} appeared.");
        yield return new WaitForSeconds(1f);
        PlayerAction();
    }
    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Make your move"));
        dialogBox.EnableActionSelector(true);
    }
    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);

    }
    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = player.Pukemon.Moves[currMove];
        yield return dialogBox.TypeDialog($"Your{player.Pukemon.Base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isdown =enemy.Pukemon.Damage(move, player.Pukemon);
        yield return enemyHud.UpdateHealth();
        if (isdown)
        {
            yield return dialogBox.TypeDialog($"Enemy {enemy.Pukemon.Base.Name} Fainted");
            yield return new WaitForSeconds(2f);
            OnBattleOver(true);
        }
        else
        {
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator EnemyAttack()
    {
        state = BattleState.EnemyMove;
        var move = enemy.Pukemon.RandomAttack();
        yield return dialogBox.TypeDialog($"Enemy {enemy.Pukemon.Base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isdown = enemy.Pukemon.Damage(move, enemy.Pukemon);
        yield return playerHud.UpdateHealth();
        if (isdown)
        {
            yield return dialogBox.TypeDialog($"Your {player.Pukemon.Base.Name} Fainted");
            yield return new WaitForSeconds(2f);
            OnBattleOver(false);
            SceneManager.LoadScene(0);
        }
        else
        {
            PlayerAction();
        }
    }

   public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if ( state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currAction < 1)
            ++currAction;
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currAction > 0)
                --currAction;
        }
        dialogBox.UpdateActionSelection(currAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currAction == 0)
            {
                PlayerMove();
            }
            else if (currAction == 1)
            {
              
            }
        }
    }
    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currMove < player.Pukemon.Moves.Count - 1)
                ++currMove;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currMove > 0)
                --currMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currMove < player.Pukemon.Moves.Count - 2)
                currMove += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currMove > 1)
                currMove -= 2;
        }
        dialogBox.UpdateMoveSelection(currMove, player.Pukemon.Moves[currMove]);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}

