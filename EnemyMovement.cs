using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyFollow Follow;
    private Patrol Patrol;
    private EnemyLineOfSight LoS;

    // Start is called before the first frame update
    void Start()
    {
        Follow = GetComponent<EnemyFollow>();
        Patrol = GetComponent<Patrol>();
        LoS = GetComponent<EnemyLineOfSight>();

        Patrol.enabled = true;
        LoS.enabled = true;
        Follow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LoS.EnemySpotted == true)
        {
            Patrol.enabled = false;
            LoS.enabled = true;
            Follow.enabled = true;
        }
        else if (LoS.EnemySpotted == false)
        {
            Patrol.enabled = true;
            LoS.enabled = true;
            Follow.enabled = false;
        }
    }
}
