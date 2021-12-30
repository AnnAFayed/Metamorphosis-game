using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Healer : MonoBehaviour
{
   
    public IEnumerator Heal(Transform player,Dialog dialog)
    {
        yield return DialogManger.Instance.ShowDialog(dialog);
     Character playerCharacter= player.GetComponent<Character>();
         playerCharacter.Heal();
        playerCharacter.CharaUpdated();
    }

      
}
