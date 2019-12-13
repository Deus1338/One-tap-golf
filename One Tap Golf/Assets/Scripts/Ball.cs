using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] float max = 10;
    [SerializeField] float current = 0;

    public Rigidbody2D rb;
    Vector2 ballVelocity = new Vector2();

    public Trajectory trajectory;
    Score scoreObject;
    public Vector3 ballStartPosition = new Vector3(-5, 0, 0);

    LevelInfo levelInfo;

    public bool isAbleToPush = true;
    private float plusVelocity;

    void Start ()
    {
        trajectory = FindObjectOfType<Trajectory>();
        scoreObject = FindObjectOfType<Score>();
        levelInfo = FindObjectOfType<LevelInfo>();
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
        DefineStartPosition();
	}

    void Update()
    {
        UpdateBallVelocity();
        ThrowTheBall();
    }

    //Every time player hits a hole velocity increases
    private void UpdateBallVelocity()
    {
        plusVelocity = 0.03f + ((scoreObject.score * 0.01f) / 2);
    }


    //Logic of throwing a ball
    private void ThrowTheBall()
    {
        if (isAbleToPush)
        {
            if (Input.GetButtonDown("Fire1") && levelInfo.menuIsInstantiated == false)
            {
                GameObject.Find("Trajectory").GetComponent<LineRenderer>().enabled = true;
                StartCoroutine("changeVelocity");
            }
            if (Input.GetButtonUp("Fire1") || current >= max)
            {
                GameObject.Find("Trajectory").GetComponent<LineRenderer>().enabled = false;
                StopCoroutine("changeVelocity");
                rb.velocity = ballVelocity;
                current = 0;
                if(levelInfo.menuIsInstantiated == false)
                {
                    isAbleToPush = false;
                }
                ballVelocity.Set(0, 0);  
            }
        }
    }

    IEnumerator changeVelocity()
    {
        while (true)
        {
            if(scoreObject.score > 0)
            {
                current += plusVelocity;
            }
            else
            {
                current += 0.03f ;
            }
            
            ballVelocity.Set(current, current);
            trajectory.ShowTrajectory(transform.position, ballVelocity);

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void DefineStartPosition()
    {
        transform.position = ballStartPosition;
        rb.velocity = ballVelocity;
    }
}
