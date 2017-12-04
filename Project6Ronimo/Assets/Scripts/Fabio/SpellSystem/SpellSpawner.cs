using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
   public void SpawnSpell(SpellHolder spell, Vector3 pos)
   {
        spell.gameObject.SetActive(true);
   }
	
}
