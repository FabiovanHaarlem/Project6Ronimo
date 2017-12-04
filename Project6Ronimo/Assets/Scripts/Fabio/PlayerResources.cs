using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    private int m_Gold;

    void Start()
    {
        m_Gold = 100;
    }

    public void AddGold(int gold)
    {
        m_Gold += gold;
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
