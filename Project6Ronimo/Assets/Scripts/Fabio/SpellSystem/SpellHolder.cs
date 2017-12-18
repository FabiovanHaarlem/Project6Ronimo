using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHolder : MonoBehaviour
{
    private ISpell m_GivenSpell;
	
	void Start ()
    {
		
	}

    public void SetSpell(ISpell spell)
    {
        m_GivenSpell = spell;
    }

    public void Activate()
    {
        m_GivenSpell.ActivateSpell();
    }

    public void Deactivate()
    {
        m_GivenSpell.DeactivateSpell();
    }
	
	void Update ()
    {
        //m_GivenSpell.UpdateSpell();
	}
}
