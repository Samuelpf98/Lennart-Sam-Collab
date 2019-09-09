using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StartTimeBtwAttack;

    public Transform attackPos;
    public float AttackRange;
    public LayerMask WhatIsEnemies;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //allows you to attack
            if (Input.GetKey(KeyCode.Mouse0)){
                Debug.Log("Enemy Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, AttackRange, WhatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {

                    enemiesToDamage[i].GetComponent<Enemy>().getHit(damage);
                }
            }
            timeBtwAttack = StartTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, AttackRange);
    }
}
