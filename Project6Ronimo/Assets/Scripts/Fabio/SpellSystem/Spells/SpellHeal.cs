using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHeal : ISpell
{
    public void ActivateSpell()
    {

    }

    public void UpdateSpell(Collider unit)
    {
        unit.GetComponent<UnitStats>().Heal(5);
    }

    public void DeactivateSpell()
    {

    }
}
