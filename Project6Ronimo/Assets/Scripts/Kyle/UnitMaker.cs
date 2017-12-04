using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaker : MonoBehaviour
{
    string m_unitchoice;
    string m_unittype;
    int m_health;
    int m_damage;
    int m_movespeed;
    int m_goldcost;

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
