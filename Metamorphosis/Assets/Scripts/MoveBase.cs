using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName ="Attack", menuName ="Character/Create new attack")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] SuperpowerTypes type;
    [SerializeField] int damage;
    [SerializeField] int mana;
    [SerializeField] int level;

    public string Name
    {
        get { return name; }
    }
    public SuperpowerTypes Type
    {
        get { return type; }
    }
    public int Damage
    {
        get { return damage; }
    }
    public int Mana
    {
        get { return mana; }
    }
    public int Level
    {
        get { return level; }
    }
}
