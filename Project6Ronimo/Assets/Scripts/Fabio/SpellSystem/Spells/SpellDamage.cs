using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : ISpell
{
    public void ActivateSpell()
    {

    }

    public void UpdateSpell(Collider unit)
    {
        unit.GetComponent<UnitStats>().TakeDamage(20);
    }

    public void DeactivateSpell()
    {

    }

}
