using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private float timeBtwAttacks;
    public float starTimeBtwAttack;

    public Transform PlayerDetection;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerinfo = Physics2D.Raycast(PlayerDetection.position, Vector2.down, 2f);
        if (timeBtwAttacks <= 0)
        {
            if (playerinfo.collider.gameObject.tag == "Player")
            {
                GameObject.Find("Player").GetComponent<PlayerHealth>().getHit();
                Debug.Log("Player hit");
            }
            timeBtwAttacks = starTimeBtwAttack;
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }

    }
}
