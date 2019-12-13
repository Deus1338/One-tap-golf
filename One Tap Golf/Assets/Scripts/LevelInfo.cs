using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour {

    
    [SerializeField] GameObject holePref;
    [SerializeField] GameObject holePrefCollider;


    Ball ballObject;
    TurnOffGroundCollider holeUpCollider;
    Hole hole;


    public bool menuIsInstantiated = false;
    public GameObject endGameMenu;


    private void Start()
    {
        ballObject = FindObjectOfType<Ball>();
        InstanciateHole();
    }


    private void Update()
    {
        EndGameCondition();
    }

    //Condition defining when the game should be finished
    private void EndGameCondition()
    {
        if (ballObject.transform.position.x != ballObject.ballStartPosition.x &&
                ballObject.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            if (menuIsInstantiated == false)
            {
                GameObject menu = InstantiateMenu();
                menu.transform.SetParent(GameObject.FindGameObjectWithTag
                    ("Canvas").transform, false);
                menuIsInstantiated = true;
            }
        }
    }

    //Used after hitting the hole to recover start position of the ball and instantiating a new hole
    public void RestartLevel()
    {
        ballObject.DefineStartPosition();
        ballObject.isAbleToPush = true;
        InstanciateHole();
    }

    //Instantiating "ENDGAME" menu
    public GameObject InstantiateMenu()
    {
        Vector3 menuPosition = new Vector3(0, 0, 0);
        GameObject a = Instantiate(endGameMenu, menuPosition, Quaternion.identity);
        return a;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //Randomly defining position of a hole
    public Vector3 DefineHolePosition()
    {
        float positionX = Random.Range(-1f, 8f);
        float positionY = 0;
        float positionZ = 0;
        Vector3 position = new Vector3(positionX, positionY, positionZ);
        return position;
    }

    //Instantiating the hole in random position defined by DefineHolePosition method
    public void InstanciateHole()
    {
        Vector3 position = DefineHolePosition();
        Instantiate(holePref, position, Quaternion.identity);
        Vector3 difference = new Vector3(0, -0.61f, 0);
        Vector3 positionCollider = position + difference;
        Instantiate(holePrefCollider, positionCollider, Quaternion.identity);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
