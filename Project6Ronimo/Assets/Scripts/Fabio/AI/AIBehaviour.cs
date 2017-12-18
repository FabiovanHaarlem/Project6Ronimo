using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    [SerializeField]
    private AIResources m_AIResources;

    [SerializeField]
    private List<GameObject> m_PlayerUnits;
    [SerializeField]
    private List<GameObject> m_AIUnits;

    [SerializeField]
    private HighestPriority m_HighestPriority;

    private float m_GoldValue;
    private float m_GoldStandard;
    [SerializeField]
    private float m_GoldPercentage;

    private float m_DefenceValue;
    private float m_DefenceStandard;
    [SerializeField]
    private float m_DefencePercentage;

    private float m_AttackValue;
    private float m_AttackStandard;
    [SerializeField]
    private float m_AttackPercentage;

    private float m_BraveryValue;
    private float m_BraveryStandard;
    [SerializeField]
    private float m_BraveryPercentage;

    private int m_ManaPool;

    private float m_PlusAmount;

    private void Start()
    {
        m_PlusAmount = 2f;
        m_GoldStandard = 250f;

        m_DefenceValue = 10f;
        m_DefenceStandard = 50f;

        m_AttackValue = 10f;
        m_AttackStandard = 50f;

        m_BraveryValue = 5f;
        m_BraveryStandard = 100f;

        m_PlayerUnits = new List<GameObject>();
        m_AIUnits = new List<GameObject>();

        GetResources();
        CalculateAINeedPercentages();
    }

    private void Update()
    {
        //For Testing
        //Buy Player Unit
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_PlayerUnits.Add(new GameObject());
        }

        //Kill Player Unit
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_PlayerUnits.RemoveAt(0);
        }

        //Buy AI Unit
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_AIUnits.Add(new GameObject());
            m_AIResources.RemoveGold(50);
        }

        //Kill AI Unit
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_AIUnits.RemoveAt(0);
        }

        //Give AI Gold
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_AIResources.AddGold(100);
        }


        UpdateValues();
        MakeChoise();
    }

    private void MakeChoise()
    {
        if (m_AttackPercentage > m_DefencePercentage)
        {
            m_HighestPriority = HighestPriority.Attack;
        }
        else if (m_DefencePercentage > m_AttackPercentage)
        {
            m_HighestPriority = HighestPriority.Defence;
        }

    }

    private void SpawnUnit(UnitStats.UnitType unit)
    {
        Debug.Log("Spawn Unit");
    }

    private void UpdateValues()
    {
        GetResources();
        UpdateAttackValue();
        UpdateDefenceValue();
        UpdateBraveryValue();
        CalculateAINeedPercentages();
    }

    private void GetResources()
    {
        m_GoldValue = m_AIResources.GetGoldValue;
        m_ManaPool = m_AIResources.GetManaPoolValue;
    }

    private void UpdateAttackValue()
    {
        if (m_PlayerUnits.Count < m_AIUnits.Count)
        {
            m_AttackValue += (m_PlusAmount * Time.deltaTime);
        }
        else if (m_PlayerUnits.Count > m_AIUnits.Count)
        {
            m_AttackValue -= (m_PlusAmount * Time.deltaTime);    
        }

        if (m_GoldPercentage <= 35f)
        {
            m_AttackValue -= m_PlusAmount * Time.deltaTime;
        }
        else
        {
            if (m_AIUnits.Count > m_PlayerUnits.Count || m_PlayerUnits.Count == 0)
            {
                m_AttackValue += m_PlusAmount * Time.deltaTime;
            }
        }

        if (m_PlayerUnits.Count == m_AIUnits.Count)
        {
            m_AttackValue += 0.5f * Time.deltaTime;
        }

        if (m_AttackValue < 0f)
        {
            m_AttackValue = 0f;
        }
        else if (m_AttackValue > m_AttackStandard * 2)
        {
            m_AttackValue = m_AttackStandard * 2;
        }
    }

    private void UpdateDefenceValue()
    {
        if (m_PlayerUnits.Count > m_AIUnits.Count)
        {
            m_DefenceValue += m_PlusAmount * Time.deltaTime;
        }
        else
        {
            m_DefenceValue -= m_PlusAmount * Time.deltaTime;
        }

        if (m_DefenceValue <= 0f)
        {
            m_DefenceValue = 0f;
        }
        else if (m_DefenceValue > m_DefenceStandard * 2)
        {
            m_DefenceValue = m_DefenceStandard * 2;
        }
    }

    private void UpdateBraveryValue()
    {
        if (m_GoldPercentage >= 100)
        {
            m_BraveryValue += 5f * Time.deltaTime;
        }
        else
        {
            m_BraveryValue -= 3f * Time.deltaTime;
        }

        if (m_BraveryValue <= 0f)
        {
            m_BraveryValue = 0f;
        }
        else if (m_BraveryValue > m_BraveryStandard * 2)
        {
            m_BraveryValue = m_BraveryStandard * 2;
        }
    }

    private void CalculateAINeedPercentages()
    {
        m_GoldPercentage = Mathf.Round((100f * m_GoldValue) / m_GoldStandard);

        m_DefencePercentage = Mathf.Round((100f * m_DefenceValue) / m_DefenceStandard);

        m_AttackPercentage = Mathf.Round((100f * m_AttackValue) / m_AttackStandard);

        m_BraveryPercentage = Mathf.Round((100f * m_BraveryValue) / m_BraveryStandard);
    }

}

public enum HighestPriority
{
    Gold = 0,
    Attack,
    Defence
}

