using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
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
        //SpecialUnit,
    };

    private UnitRange m_unitrange;
    private UnitType m_unittype;
    int m_health;
    int m_damage;
    float m_movespeed;
    int m_goldcost;

    public void SetRange(UnitRange range)
    {
        m_unitrange = range;
    }

    public UnitRange GetUnitRange()
    {
        return m_unitrange;
    }

    public void SetUnit(UnitType type)
    {
        m_unittype = type;
    }

    public UnitType GetUnitType()
    {
        return m_unittype;
    }

    public void SetHealth(int amount)
    {
        m_health = amount;
    }

    public int GetUnitHealth()
    {
        return m_health;
    }

    public void SetDamage(int amount)
    {
        m_damage = amount;
    }

    public int GetUnitDamage()
    {
        return m_damage;
    }

    public void SetMovespeed(float amount)
    {
        m_movespeed = amount;
    }

    public float GetMovespeed()
    {
        return m_movespeed;
    }

    public void SetGoldCost(int amount)
    {
        m_goldcost = amount;
    }

    public int GetGoldCost()
    {
        return m_goldcost;
    }
}
