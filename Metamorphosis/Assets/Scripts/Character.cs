using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public CharacterBase Base { get; set; }
    public int Level { get; set; }

    public int Health { get; set; }
    public List<Move> Moves { get; set; }

    public Character(CharacterBase cBase, int cLevel)
    {
        Base = cBase;
        Level = cLevel;
        Health = Base.MaxHealth; 
        Moves = new List<Move>();
    }

    public int MaxHealth
    {
        get { return Mathf.FloorToInt((Base.Speed*Level)/100f)+10; }
    }
}
