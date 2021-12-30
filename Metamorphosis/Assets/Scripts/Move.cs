using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
   public MoveBase Base { get; set; }
    public int Mana { get; set; }


    public Move(MoveBase cBase)
    {
        Base = cBase;
        Mana = cBase.Mana;
    }
}
