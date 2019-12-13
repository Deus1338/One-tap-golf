using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGroundCollider : MonoBehaviour
{
    Ball ball;
    Hole hole;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        Singleton();
    }

    //Determine that there is only 1 collider that is controlling collisions
    //between ball and ground
    private void Singleton()
    {
        int colliderCounter = FindObjectsOfType<TurnOffGroundCollider>().Length;
        if (colliderCounter > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            EnableCollision();
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DisableCollision();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnableCollision();
    }

    //Disable collision between ball and Ground
    private void DisableCollision()
    {
        Physics2D.IgnoreCollision(ball.GetComponent<CircleCollider2D>(),
                                 GameObject.Find("Ground").GetComponent<BoxCollider2D>(), true);
    }

    //Enable collision between ball and Ground
    private void EnableCollision()
    {
        Physics2D.IgnoreCollision(ball.GetComponent<CircleCollider2D>(),
                    GameObject.Find("Ground").GetComponent<BoxCollider2D>(), false);
    }

    
}
