using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    [SerializeField]
    private AIResources m_AIResources;

    private float m_GoldNeedValue;
    private float m_GoldNeedStandard;
    private float m_GoldNeedPercentage;

    private float m_DefenceNeedValue;
    private float m_DefenceNeedStandard;
    private float m_DefenceNeedPercentage;

    private float m_AttackNeedValue;
    private float m_AttackNeedStandard;
    private float m_AttackNeedPercentage;

    private float m_BraveryValue;
    private float m_BraveryStandard;
    private float m_BraveryPercentage;

    private int m_ManaPool;

    private void Start()
    {
        GetResources();
        CalculateAINeedPercentages();
    }

    private void Update()
    {
        
    }

    private void SpawnUnit(UnitStats.UnitType unit)
    {

    }

    private void GetResources()
    {
        m_GoldNeedValue = m_AIResources.GetGoldValue;
        m_ManaPool = m_AIResources.GetManaPoolValue;
    }

    private void CalculateAINeedPercentages()
    {
        m_GoldNeedStandard = 250f;
        m_GoldNeedPercentage = (100f * m_GoldNeedValue) / m_GoldNeedStandard;

        m_DefenceNeedValue = 10f;
        m_DefenceNeedStandard = 50f;
        m_DefenceNeedPercentage = (100f * m_DefenceNeedValue) / m_DefenceNeedStandard;

        m_AttackNeedValue = 10f;
        m_AttackNeedStandard = 50f;
        m_AttackNeedPercentage = (100f * m_AttackNeedValue) / m_AttackNeedStandard;

        m_BraveryValue = 5f;
        m_BraveryStandard = 100f;
        m_BraveryPercentage = (100f * m_BraveryValue) / m_BraveryStandard;
    }

}
