using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //[SerializeField] GameObject attackZone;
    Animator anim;

    private void Start()
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
