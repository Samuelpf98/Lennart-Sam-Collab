using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if the player gets hit and its health goes below 1 then the GO is destroyed
    public void getHit(int damage)
    {
        Debug.Log("Enemy Hit");
        Health = Health - damage;
        if (Health <= 0)
        {
            DestroyGameObject();
        }
    }

    //Destroys the gameobject that the script is attached too
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
