using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelectSystem : MonoBehaviour
{
    private GameManager m_GameManager;
    private SpellPool m_SpellPool;
    private SpellSpawner m_SpellSpawner;
    [SerializeField]
    private GameObject m_RaycastCaster;
    [SerializeField]
    private PlayerResources m_PlayerResources;

    private SpellHolder m_CurrentSelectedSpell;

    void Start()
    {
        m_SpellPool = GetComponent<SpellPool>();
        m_SpellSpawner = GetComponent<SpellSpawner>();
    }

    public void ActivateSpell(int spellIndex)
    {
        SpellHolder spell = m_SpellPool.GetSpells(spellIndex);

        m_CurrentSelectedSpell = spell;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_CurrentSelectedSpell != null)
            {
                if (m_PlayerResources.RemoveMana(30))
                {
                    Vector3 selectedPosition = GetSelectedPosition();
                    m_SpellSpawner.SpawnSpell(m_CurrentSelectedSpell, selectedPosition);

                    m_CurrentSelectedSpell = null;
                }
            }
        }
    }

    public Vector3 GetSelectedPosition()
    {
        RaycastHit hit;

        Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 50, Color.red);

        m_RaycastCaster.transform.position = new Vector3(hit.point.x, m_RaycastCaster.transform.position.y, m_RaycastCaster.transform.position.z);

        RaycastHit hitGround;

        Physics.Raycast(m_RaycastCaster.transform.position, Vector3.down, out hitGround, Mathf.Infinity);

        Debug.DrawRay(m_RaycastCaster.transform.position, Vector3.down * 50, Color.red);

        return hitGround.point;
    }
}
