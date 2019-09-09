using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float FollowingSpeed;
    private Transform target;
    public Transform EyeSightback;
    private bool movingRight;


    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, FollowingSpeed * Time.deltaTime);
        }

        RaycastHit2D hitInfoLeft = Physics2D.Raycast(EyeSightback.position, -transform.right);
        if (hitInfoLeft)
        {
            Player player = hitInfoLeft.transform.GetComponent<Player>();
            if (player != null)
            {
                EnemyFlip();
            }
        }
    }
    //Flips the enemy to walk in the other direction
    public void EnemyFlip()
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingRight = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingRight = true;
        }
    }
}
