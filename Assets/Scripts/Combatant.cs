using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float aggroDistance = 2f;

    float speed = 0f;
    bool isDead = false;

    Combatant[] combatants;

    Animator animator;
    Combatant target;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
        }
    }

    public void Fight()
    {
        combatants = FindObjectsOfType<Combatant>();

        foreach (Combatant combatant in combatants)
        {
            if (combatant.isDead)
            { continue; }
            if (Vector3.Distance(transform.position, combatant.transform.position) < aggroDistance)
            {
                target = combatant;
            }
        }
        if (target != null)
        {
            print(target.name);
        }
    }

    public void SetSpeed(float fSpeed)
    {
        speed = fSpeed;
        animator.SetFloat("forwardSpeed", speed);
    }
}
