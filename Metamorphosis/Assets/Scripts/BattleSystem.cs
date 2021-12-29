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
        yield return dialogBox.TypeDialog($"Evil Corp. Villian {playerUnit.Character.Base.Name} is challenging you to a battle");
        yield return new WaitForSeconds(1f);
        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose Action"));
    }
}
