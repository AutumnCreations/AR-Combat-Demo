using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    float speed = 0f;

    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        print(speed);
    }

    public void SetSpeed(float fSpeed)
    {
        speed = fSpeed;
        animator.SetFloat("forwardSpeed", speed);
    }
}
