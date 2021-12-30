using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character
{
    public CharacterBase Base { get; set; }
    public int Level { get; set; }
    public int MaxHealth { get; set; }

    public int Health { get; set; }
    public List<Move> Moves { get; set; }

    public Character(CharacterBase cBase, int cLevel)
    {
        Base = cBase;
        Level = cLevel;
        Health = Base.MaxHealth; 
        Moves = new List<Move>();
        foreach(var move in Base.LearnableAttacks)
        {
            if (move.Level<= Level)
                Moves.Add(new Move(move.Base));
            if (Moves.Count >= 10)
                break;
        }
    }

   //healing
    public int Heal()
    {
        Health = MaxHealth;
        return Health;
    }
    public event Action Onupdate;
    public void CharaUpdated()
    {
        Onupdate?.Invoke();
    }



    //public int MaxHealth
    //{
    //  get { return Mathf.FloorToInt((Base.Speed*Level)/100f)+10; }
    //}

    public bool TakeDamage(Move move, Character attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Damage;
        int damage = Mathf.FloorToInt(d * modifiers);

        Health -= damage;
        if(Health <= 0)
        {
            Health = 0;
            return true;
        }
        return false;
    }
    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
