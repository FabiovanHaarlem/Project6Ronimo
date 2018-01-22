using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnerManager : MonoBehaviour
{
    [SerializeField]
    private Transform m_PlayerBasePosition;
    [SerializeField]
    private Transform m_AIBasePosition;

    private List<GameObject> m_PlayerUnits;
    public List<GameObject> GetPlayerUnitsList
    { get { return m_PlayerUnits; } }
    private List<GameObject> m_AIUnits;
    public List<GameObject> GetAIUnitsList
    { get { return m_AIUnits; } }

    private void Start()
    {
        m_PlayerUnits = new List<GameObject>();
        m_AIUnits = new List<GameObject>();
    }

    public void SpawnUnit(GameObject unit)
    {
        unit.SetActive(true);
        unit.transform.position = m_PlayerBasePosition.position;
    }

    public void SpawnUnitAI(GameObject unit)
    {
        unit.SetActive(true);
        unit.transform.position = m_AIBasePosition.position;
    }
}
