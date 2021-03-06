using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Character _character;

    public void SetData(Character character)
    {
        _character = character;
        nameText.text = character.Base.Name;
        levelText.text = "Lvl" + character.Level;
        hpBar.SetHP((float)character.Health / character.MaxHealth);
    }

    public IEnumerator UpdateHealth()
    {
        yield return hpBar.SetHPSmoothly((float)_character.Health / _character.MaxHealth);

    }
}
