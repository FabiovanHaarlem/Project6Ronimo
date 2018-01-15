
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPool : MonoBehaviour
{
    private int m_AmountOfUnits;
    private List<UnitStats> m_UnitPoolPlayer;
    private List<UnitStats> m_UnitPoolAI;
    private PlayerFactionEnum m_PlayerFaction;
    private PlayerFactionEnum m_AIFaction;

    void Start()
    {
        m_PlayerFaction = PlayerFactionEnum.Bakasu;
        m_AIFaction = PlayerFactionEnum.Yagra;
        m_AmountOfUnits = 8;
        m_UnitPoolPlayer = new List<UnitStats>();
        m_UnitPoolAI = new List<UnitStats>();
        GetAllUnitPrefabs();
    }

    private void GetAllUnitPrefabs()
    {
        Object[] unitsPlayer = new GameObject[m_AmountOfUnits];
        Object[] unitsAI = new GameObject[m_AmountOfUnits];

        switch (m_PlayerFaction)
        {
            case PlayerFactionEnum.Bakasu:
                unitsPlayer = Resources.LoadAll("Prefabs/Bakasu");
                break;
            case PlayerFactionEnum.Yagra:
                unitsPlayer = Resources.LoadAll("Prefabs/Yagra");
                break;
            case PlayerFactionEnum.Selios:
                unitsPlayer = Resources.LoadAll("Prefabs/Selios");
                break;
        }

        switch (m_AIFaction)
        {
            case PlayerFactionEnum.Bakasu:
                unitsAI = Resources.LoadAll("Prefabs/Bakasu");
                break;
            case PlayerFactionEnum.Yagra:
                unitsAI = Resources.LoadAll("Prefabs/Yagra");
                break;
            case PlayerFactionEnum.Selios:
                unitsAI = Resources.LoadAll("Prefabs/Selios");
                break;
        }

        for (int i = 0; i < unitsPlayer.Length; i++)
        {
            for (int j = 0; j < m_AmountOfUnits; j++)
            {
                GameObject unit = Instantiate((GameObject)unitsPlayer[i]);
                m_UnitPoolPlayer.Add(unit.GetComponent<UnitStats>());

                unit = Instantiate((GameObject)unitsAI[i]);
                m_UnitPoolAI.Add(unit.GetComponent<UnitStats>());
            }
        }

        for (int i = 0; i < m_UnitPoolPlayer.Count; i++)
        {
            m_UnitPoolPlayer[i].gameObject.SetActive(false);
            m_UnitPoolAI[i].gameObject.SetActive(false);
        }
    }

    public GameObject GetSelectedUnit(string unitName, int side)
    {
        GameObject unit = null;
        UnitStats.UnitType unitType = unitType = UnitStats.UnitType.Collector;

        switch(unitName)
        {
            case "Collector":
                unitType = UnitStats.UnitType.Collector;
                break;
            case "Melee":
                unitType = UnitStats.UnitType.SwordMaster;
                break;
            case "Ranged":
                unitType = UnitStats.UnitType.Archer;
                break;
            case "Spellcaster":
                unitType = UnitStats.UnitType.Spellcaster;
                break;
            case "Special":
                unitType = UnitStats.UnitType.SpecialUnit;
                break;
        }


        if (side == 0)
        {
            for (int i = 0; i < m_UnitPoolPlayer.Count; i++)
            {
                if (m_UnitPoolPlayer[i].GetUnitType() == unitType)
                {
                    if (!m_UnitPoolPlayer[i].gameObject.activeInHierarchy)
                    {
                        unit = m_UnitPoolPlayer[i].gameObject;
                        //Set unit side to attack
                    }
                }
            }
        }
        else if (side == 1)
        {
            for (int i = 0; i < m_UnitPoolAI.Count; i++)
            {
                if (m_UnitPoolAI[i].GetUnitType() == unitType)
                {
                    if (!m_UnitPoolAI[i].gameObject.activeInHierarchy)
                    {
                        unit = m_UnitPoolAI[i].gameObject;
                        //Set unit side to attack
                    }
                }
            }
        }

        return unit;
    }

}
