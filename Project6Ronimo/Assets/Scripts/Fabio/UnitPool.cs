
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    private int m_AmountOfUnits;
    private List<GameObject> m_UnitPool;

    void Start()
    {
        m_AmountOfUnits = 4;
        m_UnitPool = new List<GameObject>();
        GetAllUnitPrefabs();
    }

    private void GetAllUnitPrefabs()
    {
        for (int i = 0; i < m_AmountOfUnits; i++)
        {
            m_UnitPool.Add(Instantiate(Resources.Load<GameObject>("Prefabs/TestUnits/CollectorUnitTest")));
            m_UnitPool.Add(Instantiate(Resources.Load<GameObject>("Prefabs/TestUnits/MeleeUnitTest")));
            m_UnitPool.Add(Instantiate(Resources.Load<GameObject>("Prefabs/TestUnits/RangedUnitTest")));
            m_UnitPool.Add(Instantiate(Resources.Load<GameObject>("Prefabs/TestUnits/SpellCasterUnitTest")));
            m_UnitPool.Add(Instantiate(Resources.Load<GameObject>("Prefabs/TestUnits/SpecialUnitTest")));
        }

        for (int i = 0; i < m_UnitPool.Count; i++)
        {
            m_UnitPool[i].SetActive(false);
        }
    }

    public GameObject GetSelectedUnit(string unitName)
    {
        GameObject unit = null;

        for (int i = 0; i < m_UnitPool.Count; i++)
        {
            if (m_UnitPool[i].name == unitName)
            {
                if (!m_UnitPool[i].activeInHierarchy)
                {
                    unit = m_UnitPool[i];
                }
            }
        }

        return unit;
    }

}
