using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    Combatant[] combatants;

    public void Fight()
    {
        combatants = FindObjectsOfType<Combatant>();
        foreach (Combatant combatant in combatants)
        {
            combatant.Fight();
        }
    }
}
