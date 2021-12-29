using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    

    public void SetData(Character character)
    {
        nameText.text = character.Base.Name;
        levelText.text = "Lvl" + character.Level;
        hpBar.SetHP((float)character.Health / character.MaxHealth);
    }
}
