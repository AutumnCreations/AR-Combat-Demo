using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlider : MonoBehaviour
{
    Combatant[] combatants;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        combatants = FindObjectsOfType<Combatant>();
    }

    public 
        void AdjustSpeed(float speedToSet)
    {
        foreach (Combatant combatant in combatants)
        {
            combatant.SetSpeed(speedToSet);
        }
    }
}
