using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    void ActivateSpell();

    void UpdateSpell(Collider unit);

    void DeactivateSpell();
}
