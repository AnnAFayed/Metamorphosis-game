using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}
public class BattleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;
    int currentMove;
    private void Start()
    {
        StartCoroutine( SetupBattle());
    }
    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        playerHud.SetData(playerUnit.Character);
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Character);

        dialogBox.SetMoveNames(playerUnit.Character.Moves);

        yield return dialogBox.TypeDialog($"Evil Corp. villian, {enemyUnit.Character.Base.Name} is challenging you to a battle!");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an Action"));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = playerUnit.Character.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{ playerUnit.Character.Base.Name}used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isDefeated = enemyUnit.Character.TakeDamage(move, playerUnit.Character);
        yield return enemyHud.UpdateHealth();
        if (isDefeated)
        {
            yield return dialogBox.TypeDialog($"{ enemyUnit.Character.Base.Name} was defeated");

        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }
    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        var move = playerUnit.Character.GetRandomMove();
        yield return dialogBox.TypeDialog($"{ enemyUnit.Character.Base.Name}used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isDefeated = playerUnit.Character.TakeDamage(move, enemyUnit.Character);
        yield return playerHud.UpdateHealth();
        if (isDefeated)
        {
            yield return dialogBox.TypeDialog($"{ playerUnit.Character.Base.Name} was defeated");

        }
        else
        {
            PlayerAction();
        }
    }
    private void Update()
    {
        if(state== BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if(state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

     void HandleActionSelection() {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }
        dialogBox.UpdateActionSelection(currentAction);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(currentAction == 0)
            {
                //Fight
                PlayerMove();
            }
            else if(currentAction == 1)
            {
                //items
            }
        }
    }
    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Character.Moves.Count - 1)
                ++currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Character.Moves.Count - 2)
                currentMove += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
                currentMove -= 2;
        }
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Character.Moves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }

    
    }
}
