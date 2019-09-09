using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{

    public float distance;
    public Transform EyeSight;
    public bool EnemySpotted;

    public float viewTimer;
    private float timeBtwView;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpotted = false;
        timeBtwView = viewTimer;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hitInfoRight = Physics2D.Raycast(EyeSight.position, transform.right, distance);

            if (hitInfoRight)
            {
            Player player = hitInfoRight.transform.GetComponent<Player>();
            if(player != null)
            {
                EnemySpotted = true;
                timeBtwView = viewTimer;
                PlayerMissing();
                
            }

           
            }
        if (EnemySpotted == true)
        {
            PlayerMissing();
        }
       
        }
    public void PlayerMissing()
    {
        
        if (timeBtwView <= 0)
        {
            EnemySpotted = false;
        }
        else
        {
            timeBtwView -= Time.deltaTime;
        }
    }

  
      
          
        
    }
