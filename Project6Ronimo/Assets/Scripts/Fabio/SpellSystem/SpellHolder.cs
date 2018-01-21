using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    private ISpell m_GivenSpell;
    private Spells m_SpellValues;

    private float m_SpellDuration;
	

    public void SetSpell(ISpell spell, Spells spellsValue)
    {
        m_GivenSpell = spell;
        m_SpellValues = spellsValue;
        m_SpellDuration = m_SpellValues.GetSpellDuration;
    }

    public void Activate()
    {
        m_GivenSpell.ActivateSpell();
    }

    public void Deactivate()
    {
        m_GivenSpell.DeactivateSpell();
        this.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        m_SpellDuration -= Time.deltaTime;

        if (m_SpellDuration <= 0f)
        {
            Deactivate();
            m_SpellDuration = m_SpellValues.GetSpellDuration;
        }
	}

    private void OnTriggerStay(Collider unit)
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector2(2f, 1f), transform.rotation);
        m_GivenSpell.UpdateSpell(unit);
    }
}
