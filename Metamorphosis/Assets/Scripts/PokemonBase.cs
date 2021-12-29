using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Character", menuName ="Character/Create new character")]
public class CharacterBase : ScriptableObject
// Start is called before the first frame update
{
    [SerializeField] string name;

    [SerializeField] Sprite frontSprite;

    [SerializeField] SuperpowerTypes type;


    [SerializeField] int maxHealth;
    [SerializeField] int speed;
    [SerializeField] int level;


    //properties
    public string Name   
    {
        get { return name; }
    }
    public Sprite FrontSprite
    {
        get { return frontSprite; }
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
}

public enum SuperpowerTypes
{
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
 witch,
 wizard,
 Speed,
 Force_Field,
 Mimicking,
 Magnetic_Mastery


}