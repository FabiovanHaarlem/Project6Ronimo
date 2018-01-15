using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public enum Faction
    {
        Yagra,
        Selios,
        Bakasu
    };

    public enum UnitRange
    {
        Melee,
        Ranged
    };

    public enum UnitType
    {
        Collector,
        SwordMaster,
        Spellcaster,
        Archer,
        SpecialUnit,
    };

    /*
    [HideInInspector]public UnitRange m_unitrange;
    [HideInInspector]public UnitType m_unittype;
    [HideInInspector]public int m_health;
    [HideInInspector]public int m_damage;
    [HideInInspector]public float m_movespeed;
    [HideInInspector]public int m_goldcost;
    */

    public Faction m_faction;
    public UnitRange m_unitrange;
    public UnitType m_unittype;
    public int m_health;
    public int m_damage;
    public float m_movespeed;
    public int m_goldcost;
    public RuntimeAnimatorController m_animator;

    public void Initialize(Faction faction, UnitRange unitrange, UnitType unittype, int healthamount, int damageamount, float movespeed, int goldcost, RuntimeAnimatorController animator, Sprite unitsprite)
    {
        m_faction = faction;
        m_unitrange = unitrange;
        m_unittype = unittype;
        m_health = healthamount;
        m_damage = damageamount;
        m_movespeed = movespeed;
        m_goldcost = goldcost;
        m_animator = animator;

        GetComponent<SpriteRenderer>().sprite = unitsprite;
    }

    public Faction GetFaction()
    {
        return m_faction;
    }
    public UnitRange GetUnitRange()
    {
        return m_unitrange;
    }
    public UnitType GetUnitType()
    {
        return m_unittype;
    }
    public int GetUnitHealth()
    {
        return m_health;
    }
    public int GetUnitDamage()
    {
        return m_damage;
    }
    public float GetMovespeed()
    {
        return m_movespeed;
    }
    public int GetGoldCost()
    {
        return m_goldcost;
    }
    public RuntimeAnimatorController GetAnimator()
    {
        return m_animator;
    }

    void TakeDamage(int amountofdamage)
    {
        m_health = m_health - amountofdamage;
    }

    void Heal(int amountofheal)
    {
        m_health = m_health + amountofheal;
    }
}
