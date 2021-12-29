using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName ="Character/Create new character")]
public class CharacterBase : ScriptableObject
// Start is called before the first frame update
{
    [SerializeField] string name;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] SuperpowerTypes type;
    [SerializeField] SuperpowerTypes type2;
    [SerializeField] SuperpowerTypes type3;
    [SerializeField] SuperpowerTypes type4;
    [SerializeField] SuperpowerTypes type5;

    [SerializeField] int maxHealth;
    [SerializeField] int speed;
    [SerializeField] int level;

    [SerializeField] List<LearnableAttack> learnableAttacks;
    //properties
    public string Name   
    {
        get { return name; }
    }
    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }
    public Sprite BackSprite
    {
        get { return backSprite; }
    }
    public SuperpowerTypes Type
    {
        get { return type; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public int Speed
    {
        get { return speed; }
    }
    public int Level
    {
        get { return level; }
    }
    public List<LearnableAttack> LearnableAttacks
    {
        get { return learnableAttacks; }
    }

}

[System.Serializable]
public class LearnableAttack
{
    [SerializeField] MoveBase moveBase;
    public MoveBase Base
    {
        get { return moveBase; }
    }
}

public enum SuperpowerTypes
{
    None,
 Laser_Vision,
 Fists_of_Steel,
 Invisibility,
 Flames,
 Telekinesis,
 Wolf_Claws,
 Lighting,
 Strength,
 Flying,
 Electricity,
 Fire_Manipulation,
 Water_Manipulation,
 Acid,
 Earth_Manipulation,
 Demonic,
 Magic,
 Speed,
 Force_Field,
 Mimicking,
 Magnetic_Mastery


}