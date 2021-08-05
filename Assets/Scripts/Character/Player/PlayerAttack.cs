using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;


    public void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
    }

    public void AttackEnd()
    {
        anim.SetBool("Attack", false);
    }
}
