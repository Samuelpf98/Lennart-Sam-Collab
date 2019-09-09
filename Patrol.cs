using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;

    public Transform GroundDetection;

    

    void Update()
    {

        //Detects if their is an edge in order to not go off it
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundinfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 2f);
        if (groundinfo.collider == false)
        {
            EnemyFlip();
        }


    }

    //Detects if a wall is infront of them and flips around
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            EnemyFlip();
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
