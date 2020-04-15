using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Combatant : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float aggroDistance = 5f;
    [SerializeField] float stoppingDistance = 1f;

    float speed = 0f;
    public bool isDead = false;

    Combatant[] combatants;

    Animator animator;
    CharacterController controller;
    Combatant target;
    State state;

    private enum State
    {
        Idle,
        Normal,
        Moving,
        Attacking,
        Dead,
    }

    void Start()
    {
        state = State.Idle;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                break;
            case State.Normal:
                SearchForTargets();
                break;
            case State.Moving:
                MoveTowardsTarget();
                break;
            case State.Attacking:
                AttackTarget();
                break;
            case State.Dead:
                return;
        }
        if (health <= 0)
        {
            isDead = true;
            state = State.Dead;
        }
    }

    private void AttackTarget()
    {
        SetSpeed(0);
        if (!target.isDead)
        {
            print(gameObject.name + " is attacking " + target.name);
        }
        else
        {
            target = null;
            state = State.Normal;
        }
    }

    public void MoveTowardsTarget()
    {
        Vector3 velocity = transform.forward * speed;
        if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            transform.LookAt(target.transform.position);
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            state = State.Attacking;
        }

    }

    public void SearchForTargets()
    {
        combatants = FindObjectsOfType<Combatant>();

        foreach (Combatant combatant in combatants)
        {
            if (combatant == gameObject.GetComponent<Combatant>())
            { continue; }
            if (combatant.isDead)
            { continue; }
            if (Vector3.Distance(transform.position, combatant.transform.position) < aggroDistance)
            {
                target = combatant;
            }
        }
        if (target != null)
        {
            print(gameObject.name + "'s target is " + target.name);
            state = State.Moving;
        }
    }

    public void SetSpeed(float fSpeed)
    {
        speed = fSpeed;
        animator.SetFloat("forwardSpeed", speed);
    }

    private void OnDrawGizmosSelected()
    {
        Color gizmoColor = Color.cyan;
        Gizmos.color = gizmoColor;

        Gizmos.DrawWireSphere(transform.position, aggroDistance);
    }
}
