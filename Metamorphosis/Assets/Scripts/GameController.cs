using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum GameState { FreeRoam,Battle,Dialog,Bag}

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playercontroller;
    //[SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    GameState state;
   [SerializeField]InventoryUI inventoryUI;   //for inventory
   // private void Awake()
    //{
        //ConditionsDB.Init();
    //}
    // Start is called before the first frame update
   private void Start()
    {
       // playercontroller.OnEncountered += StartBattle;
        //battleSystem.OnBattleOver += EndBattle;

        DialogManger.Instance.OnShowDialog += () =>
         {
             state = GameState.Dialog;
         };
        DialogManger.Instance.OnCloseDialog += () =>
        {
            if (state==GameState.Dialog)
            state = GameState.FreeRoam;
        };
    }
    /*void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);
        var playerParty = playercontroller.GetComponent<PokemonParty>();//change
        var wildpokemon = FindObjectOfType<MapArea>().GetComponent<MapArea>().GetRandomWildPokemon();//change
        battleSystem.StartBattle(playerParty, wildpokemon);
    }
    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);
    }
    */
    // Update is called once per frame
    private void Update()
    {
        if(state ==GameState.FreeRoam)
        {
            //playercontroller.HandleUpdate();
            if (Input.GetKeyDown(KeyCode.S))
            {
                SavingSystem.i.Save("saveSlot1");
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                SavingSystem.i.Load("saveSlot1");
            }
        }
        /*else if (state ==GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }*/
      else if (state==GameState.Dialog) 
        {
            DialogManger.Instance.HandleUpdate();
        }

      if(state == GameState.Bag)
        {
            Action onBack = () =>
              {
                  inventoryUI.gameObject.SetActive(false);
                  state = GameState.FreeRoam;
              };
            inventoryUI.HandleUpdate(onBack);
        }
        
    }
      //FOR INVENTORY
    void OnMenuSelected(int selectedItem)
    {
        if (selectedItem == 1)
        {
            inventoryUI.gameObject.SetActive(true);
            state = GameState.Bag;
        }
    }
    
}
