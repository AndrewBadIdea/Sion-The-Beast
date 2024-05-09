using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update


    //melee
    public GameObject attArea;
    public bool isAttacking = false;
    public float atkDuration = 0.5f;
    public bool canAttack = true;
    public float attackSpeed = 1.5f;
    
    //range
    public Transform direction;
    public GameObject bullet;
    public float fireForce = 10f;
    private float shootCd = 0.25f;
    private float shootTimer = 0.5f;

    movement play;

    private void Start()
    {
        play = GetComponentInParent<movement>();
    }

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            OnAttack();
        }
        animator.SetBool("isAtk", isAttacking);
    }

    private void OnAttack()
    {
        if (canAttack && play.isDead == false)
        {
            StartCoroutine(AttackSpeed());
        }
        else
        {
            return;
        }
    }
    private IEnumerator AttackSpeed()
    {
        isAttacking = true;
        attArea.SetActive(true);


        yield return new WaitForSeconds(atkDuration);

        canAttack = false;
        isAttacking = false;
        attArea.SetActive(false);

        yield return new WaitForSeconds(attackSpeed);
        canAttack = true;
    }
}
