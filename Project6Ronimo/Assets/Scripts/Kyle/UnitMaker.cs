using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker : MonoBehaviour
{
    [HideInInspector] public string m_unitchoice;
    [HideInInspector] public string m_unittype;
    [HideInInspector] public int m_health;
    [HideInInspector] public int m_damage;
    [HideInInspector] public int m_movespeed;
    [HideInInspector] public int m_goldcost;

    public void SetUnitChoice(string choice)
    {
        m_unitchoice = choice;
    }

    public void SetUnitType(string choice)
    {
        m_unittype = choice;
    }

    public void SetHealth(int amount)
    {
        m_health = amount;
    }

    public void SetDamage(int amount)
    {
        m_damage = amount;
    }

    public void SetMovespeed(int amount)
    {
        m_movespeed = amount;
    }

    public void SetGoldCost(int amount)
    {
        m_goldcost = amount;
    }
}
