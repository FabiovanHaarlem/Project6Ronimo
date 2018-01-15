using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TestSpell;

    public void SpawnSpell(SpellHolder spell, Vector3 pos)
    {
        spell.gameObject.SetActive(true);
        spell.gameObject.transform.position = pos;

        //m_TestSpell.SetActive(true);
        //m_TestSpell.transform.position = pos;
    }

}
