using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIResources : MonoBehaviour
{
    private int m_Gold;
    public int GetGoldValue
    { get { return m_Gold; } }

    private int m_ManaPool;
    public int GetManaPoolValue
    { get { return m_ManaPool; } }

    private float m_ManaRechargeSpeed;

    private void Start()
    {
        m_Gold = 100;
        m_ManaPool = 100;
        m_ManaRechargeSpeed = 3f;
    }

    public void AddGold(int gold)
    {
        m_Gold += gold;
    }

    public void RechargeMana()
    {
        m_ManaPool += 1;
        m_ManaRechargeSpeed = 3f;
    }

    public bool RemoveMana(int manaCost)
    {
        if (m_ManaPool - manaCost <= -1)
        {
            return false;
        }
        else
        {
            m_ManaPool -= manaCost;
            return true;
        }
    }

    public bool RemoveGold(int gold)
    {
        if (m_Gold - gold <= -1)
        {
            return false;
        }
        else
        {
            m_Gold -= gold;
            return true;
        }
    }
}
