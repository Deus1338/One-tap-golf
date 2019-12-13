using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    //[SerializeField] GameObject hole;
    Score objectScore;
    LevelInfo levelInfo;
    public bool holeIsHit = false;


    private void Start()
    {
        objectScore = FindObjectOfType<Score>();
        levelInfo = FindObjectOfType<LevelInfo>();
    }

    private void Update()
    {
        AfterHoleIsHit();
    }

    //Condition of restarting level after hiting the hole
    private void AfterHoleIsHit()
    {
        if (holeIsHit == true)
        {
            objectScore.AddScore();
            Destroy(gameObject);
            levelInfo.RestartLevel();
            holeIsHit = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        holeIsHit = true;
    }
}
