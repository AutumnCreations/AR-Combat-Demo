using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    float speed = 0f;
    float health = 100f;
    bool isDead = false;

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

        target = FindObjectOfType<Combatant>();
        if (target.isDead)
        {

        }
    }

    public void SetSpeed(float fSpeed)
    {
        speed = fSpeed;
        animator.SetFloat("forwardSpeed", speed);
    }
}
