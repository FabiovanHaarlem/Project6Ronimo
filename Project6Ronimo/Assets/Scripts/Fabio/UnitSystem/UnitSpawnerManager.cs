using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnerManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_PlayerBasePosition;
    [SerializeField]
    private Vector3 m_AIBasePosition;

    public void SpawnUnit(GameObject unit)
    {
        unit.SetActive(true);
        unit.transform.position = m_PlayerBasePosition;
    }
}
