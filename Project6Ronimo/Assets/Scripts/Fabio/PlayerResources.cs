using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour, IResources
{
    private int m_Gold;
    private int m_ManaPool;
    private float m_ManaRechargeSpeed;

    void Start()
    {
        m_Gold = 100;
        m_ManaPool = 100;
        m_ManaRechargeSpeed = 3f;
    }

    private void Update()
    {
        m_ManaRechargeSpeed -= Time.deltaTime;

        if (m_ManaRechargeSpeed <= 0f)
        {
            if (m_ManaPool >= 100)
            {
                RechargeMana();
            }
        }
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
