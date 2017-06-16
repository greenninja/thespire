using Assets;
using Assets.Game.CharacterCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{

  
    private string m_Name = "";
    private int m_Level = 1;
    private int m_Experience = 0;

    private int m_Strength;
    private int m_Dexterity;
    private int m_Endurance;
    private int m_Intellect;
    private int m_Charisma;
    private int m_Toughness;
    private int m_Perception;

    private int m_Health;
    private int m_Mana;
    private int m_Stamina;

    private int m_Sight;
    private int m_Intimidation;
    private int m_Barter;
    private int m_Initiative;
    private int m_Sneak;

    private Race ChosenRace = Race.Orc;
    private Class ChosenClass = Class.WARRIOR;

    public Dictionary<RaceSkill, ClassSkill> SkillList = new Dictionary<RaceSkill, ClassSkill>();

    public CreateCharacter()
    {
        Debug.Log("Create Character Constructor");
        Name(m_Name);
        Debug.Log(m_Name);
        ApplyRaceAndClass(ChosenRace, ChosenClass);
        Debug.Log(ChosenRace);
        Debug.Log(ChosenClass);
        Debug.Log("Strength" + Strength);
        Debug.Log("Intellect" + Intellect);


    }



    public string Name(string pName)
    {
        m_Name = pName;
        return m_Name;
    }

  


    private int CheckExp(int pExperience)
    {
        m_Experience = pExperience;

        return m_Experience;
    }


    public enum Race
    {
        Human,
        Orc,
        Elf,
        Dwarf

    }

    public enum Class
    {
        WARRIOR,
        PALADIN,
        SORCERER,
        ROGUE,
        RANGER,
        WIZARD,
        PRIEST

    }
    private void ApplyRaceAndClass(Race pRace, Class pClass)
    {
        ChosenRace = pRace;
        ChosenClass = pClass;

        if (ChosenRace == Race.Human)
        {
            Strength = 10; //Shit in here.
            Dexterity = 10;
            Endurance = 10;
            Intellect = 10;
            Toughness = 10;
            Charisma = 10;
            Perception = 10;

            Health += 5;
            Stamina += 0;
            Mana -= 5;

            Sight += 0;
            Intimidation += 2;
            Barter += 0;
            Initiative += 0;
            Sneak += 0;

        }
        else if (ChosenRace == Race.Elf)
        {
            Strength = 10; //Shit in here.
            Dexterity = 10;
            Endurance = 10;
            Intellect = 10;
            Toughness = 10;
            Charisma = 10;
            Perception = 10;

            Health += 5;
            Stamina += 0;
            Mana -= 5;

            Sight += 0;
            Intimidation += 2;
            Barter += 0;
            Initiative += 0;
            Sneak += 0;
        }
        else if (ChosenRace == Race.Dwarf)
        {
            Strength = 10; //Shit in here.
            Dexterity = 10;
            Endurance = 10;
            Intellect = 10;
            Toughness = 10;
            Charisma = 10;
            Perception = 10;

            Health += 5;
            Stamina += 0;
            Mana -= 5;

            Sight += 0;
            Intimidation += 2;
            Barter += 0;
            Initiative += 0;
            Sneak += 0;


        }
        else if (ChosenRace == Race.Orc)
        {
            Strength = 20; //Shit in here.
            Dexterity = 10;
            Endurance = 10;
            Intellect = 5;
            Toughness = 10;
            Charisma = 10;
            Perception = 10;

            Health += 5;
            Stamina += 0;
            Mana -= 5;

            Sight += 0;
            Intimidation += 2;
            Barter += 0;
            Initiative += 0;
            Sneak += 0;

        }



    }
    public int Strength
    {
        get
        {
            return m_Strength;
        }
        set
        {
            m_Strength = value;
        }
    }
    public int Dexterity
    {
        get
        {
            return m_Dexterity;
        }
        set
        {
            m_Dexterity = value;
        }
    }
    public int Endurance
    {
        get
        {
            return m_Endurance;
        }
        set
        {
            m_Endurance = value;
        }
    }
    public int Intellect
    {
        get
        {
            return m_Intellect;
        }
        set
        {
            m_Intellect = value;
        }
    }
    public int Toughness
    {
        get
        {
            return m_Toughness;
        }
        set
        {
            m_Toughness = value;
        }
    }
    public int Charisma
    {
        get
        {
            return m_Charisma;
        }
        set
        {
            m_Charisma = value;
        }
    }
    public int Perception
    {
        get
        {
            return m_Perception;
        }
        set
        {
            m_Perception = value;
        }
    }

    public int Health
    {
        get
        {
            return m_Health;
        }
        set
        {
            m_Health = value;
        }
    }
    public int Stamina
    {
        get
        {
            return m_Stamina;
        }
        set
        {
            m_Stamina = value;
        }
    }
    public int Mana
    {
        get
        {
            return m_Mana;
        }
        set
        {
            m_Mana = value;
        }
    }

    public int Level
    {
        get
        {
            return m_Level;
        }

        set
        {
            m_Level = value;
        }
    }
    public int Experience
    {
        get
        {
            return m_Experience;
        }
        set
        {
            m_Experience = value;
        }
    }

    public int Sight
    {
        get
        {
            return m_Perception/10;
        }
        set
        {
            m_Sight = value;
        }
    }
    public int Intimidation
    {
        get
        {
            return m_Intimidation + m_Strength;
        }
        set
        {
            m_Intimidation = value;
        }
    }
    public int Barter
    {
        get
        {
            return m_Barter + m_Charisma;
        }
        set
        {
            m_Barter = value;
        }
    }
    public int Initiative
    {
        get
        {
            return m_Initiative + m_Dexterity;
        }
        set
        {
            m_Initiative = value;
        }
    }
    public int Sneak
    {
        get
        {
            return m_Sneak + m_Dexterity;
        }
        set
        {
            m_Sneak = value;
        }
    }
}
