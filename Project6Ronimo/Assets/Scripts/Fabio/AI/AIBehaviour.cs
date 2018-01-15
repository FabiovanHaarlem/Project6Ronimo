using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    [SerializeField]
    private AIResources m_AIResources;

    [SerializeField]
    private UnitSpawnerManager m_UnitSpawner;

    [SerializeField]
    private UnitSelectManager m_UnitSelectManager;

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

    private int m_AmountOfCollectors;
    private int m_CollectorsLimit;
    private float m_NewCollectorLimitTimer;

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

        m_AmountOfCollectors = 0;
        m_CollectorsLimit = 3;
        m_NewCollectorLimitTimer = 60f;

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

        m_NewCollectorLimitTimer -= Time.deltaTime;

        if (m_NewCollectorLimitTimer <= 0f)
        {
            m_CollectorsLimit += 1;
            m_NewCollectorLimitTimer = 60f;
        }

        if (m_GoldPercentage <= 15f || m_GoldPercentage >= 85)
        {
            if (m_PlayerUnits.Count <= m_AIUnits.Count && m_AmountOfCollectors <= m_CollectorsLimit)
            {
                SpawnCollector();
            }
        }

        if (m_DefencePercentage >= 40f)
        {
            List<string> unitsToSpawn = new List<string>();
            
            if (m_GoldPercentage >= 80f)
            {
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Ranged");
            }
            else if (m_GoldPercentage >= 50f)
            {
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Ranged");
            }
            else if (m_GoldPercentage >= 30f)
            {
                unitsToSpawn.Add("Melee");
            }

            SpawnUnit(unitsToSpawn);
        }
        else if (m_AttackPercentage >= 40f)
        {
            List<string> unitsToSpawn = new List<string>();

            if (m_GoldPercentage >= 80f)
            {
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Ranged");
                unitsToSpawn.Add("Spellcaster");
            }
            else if (m_GoldPercentage >= 50f)
            {
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Ranged");
                unitsToSpawn.Add("Ranged");
            }
            else if (m_GoldPercentage >= 30f)
            {
                unitsToSpawn.Add("Melee");
                unitsToSpawn.Add("Ranged");
            }
            else if (m_GoldPercentage >= 20f)
            {
                unitsToSpawn.Add("Melee");
            }

            SpawnUnit(unitsToSpawn);
        }
    }

    private void SpawnCollector()
    {
        m_UnitSelectManager.SpawnAIUnit("Collector", m_AIResources);
    }

    private void SpawnUnit(List<string> unitsToSpawn)
    {
        for (int i = 0; i < unitsToSpawn.Count; i++)
        {
            m_UnitSelectManager.SpawnAIUnit(unitsToSpawn[i], m_AIResources);
        }
    }

    private void UpdateValues()
    {
        m_PlayerUnits = m_UnitSpawner.GetPlayerUnitsList;
        m_AIUnits = m_UnitSpawner.GetAIUnitsList;

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

