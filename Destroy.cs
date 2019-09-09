using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.name == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
