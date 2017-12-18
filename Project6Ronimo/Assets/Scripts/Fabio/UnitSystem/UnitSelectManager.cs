using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_SelectableSymbols;
    [SerializeField]
    private GameObject m_UpradesGroup;
    [SerializeField]
    private Canvas m_Canvas;
    [SerializeField]
    private UnitCosts m_UnitCosts;
    [SerializeField]
    private PlayerResources m_PlayerResources;

    private RectTransform m_CanvasRectTransform;
    private UnitPool m_UnitPool;
    private UnitSpawnerManager m_Spawner;

    private bool m_UpgradeMenuOpen;
    private bool m_SelectMenuActive;

    void Start()
    {
        m_UnitPool = GetComponent<UnitPool>();
        m_Spawner = GetComponent<UnitSpawnerManager>();
        m_CanvasRectTransform = m_Canvas.gameObject.GetComponent<RectTransform>();
        m_SelectableSymbols.gameObject.SetActive(false);
        m_UpgradeMenuOpen = false;
        m_UpradesGroup.SetActive(false);
        m_SelectMenuActive = false;
    }

    private void Update()
    {
        if (m_SelectableSymbols.activeInHierarchy)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRectTransform,
                Input.mousePosition, m_Canvas.worldCamera, out pos);

            if (m_UpgradeMenuOpen)
            {
                if (Vector2.Distance(m_SelectableSymbols.transform.position, Input.mousePosition) > 350f)
                {
                    m_UpradesGroup.SetActive(false);
                    m_UpgradeMenuOpen = false;
                    m_SelectableSymbols.SetActive(false);
                }
            }
            else if (Vector2.Distance(m_SelectableSymbols.transform.position, Input.mousePosition) > 200f)
            {
                m_SelectableSymbols.SetActive(false);
            }
        }

        if (m_SelectMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DeactivateSelect();
                m_SelectMenuActive = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetUIElements();
            m_SelectMenuActive = true;
        }
        
    }

    public void SpawnUnit(string unitName)
    {
        if (CheckIfEnoughGold(unitName))
        {
            GameObject unit = m_UnitPool.GetSelectedUnit(unitName);
            m_Spawner.SpawnUnit(unit);
        }
    }

    private bool CheckIfEnoughGold(string unitName)
    {
        bool spawnUnit = false;

        if (unitName == "Collector")
        {
            if (m_PlayerResources.RemoveGold(m_UnitCosts.GetCollectorCost))
            {
                spawnUnit = true;
            }
        }
        else if (unitName == "Melee")
        {
            if (m_PlayerResources.RemoveGold(m_UnitCosts.GetMeleeCost))
            {
                spawnUnit = true;
            }
        }
        else if (unitName == "Ranged")
        {
            if (m_PlayerResources.RemoveGold(m_UnitCosts.GetRangedCost))
            {
                spawnUnit = true;
            }
        }
        else if (unitName == "Spellcaster")
        {
            if (m_PlayerResources.RemoveGold(m_UnitCosts.GetSpellcasterCost))
            {
                spawnUnit = true;
            }
        }
        else if (unitName == "Special")
        {
            if (m_PlayerResources.RemoveGold(m_UnitCosts.GetSpecialCost))
            {
                spawnUnit = true;
            }
        }

        return spawnUnit;
    }

    private void DeactivateSelect()
    {
        m_UpradesGroup.SetActive(false);
        m_UpgradeMenuOpen = false;
        m_SelectableSymbols.SetActive(false);
        m_SelectMenuActive = false;
    }

    public void OpenUpgradePanel()
    {
        m_UpgradeMenuOpen = true;
        m_UpradesGroup.SetActive(true);
    }

    public void Upgrade(string upgrade)
    {

    }

    public void SetUIElements()
    {
        if (!m_SelectableSymbols.activeInHierarchy)
        {
            m_SelectableSymbols.SetActive(true);
            m_UpradesGroup.SetActive(true);
        }

        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_CanvasRectTransform,
            Input.mousePosition, m_Canvas.worldCamera, out pos);

        m_SelectableSymbols.transform.position = m_Canvas.gameObject.transform.TransformPoint(pos);
        m_UpradesGroup.SetActive(false);
    }
}
