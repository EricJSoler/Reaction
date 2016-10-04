using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject blueDot;
    public GameObject redDot;
    CircleScript blueScript;
    RedCircleScript redScript;

    GameGUI gameGUI;

    private int score;
    bool bluered = false;
    private int blueredInt = 0;
    private int colorText = 0;


    public GameObject blueExplosion;
    public GameObject redExplosion;
    public GameObject X_GameOver;


    // Use this for initialization
    void Start () {
        score = 0;
        
        X_GameOver.SetActive(false);
        blueScript = blueDot.GetComponent<CircleScript>();
        redScript = redDot.GetComponent<RedCircleScript>();
        gameGUI = FindObjectOfType<GameGUI>();
        gameGUI.setScore(0);
        generateNewMove();
    }
	
	// Update is called once per frame
	void Update () {
	
    
	}

    public void blueMove(Transform dotPosition)
    {
        if(bluered)
        {
            score++;
            gameGUI.setScore(score);

            Instantiate(blueExplosion, dotPosition.position, Quaternion.identity);

            blueScript.changePosition();
            redScript.changePosition();
            generateNewMove();
        }
        else
        {
            X_GameOver.SetActive(true);
            X_GameOver.transform.position = dotPosition.position;
            
            StartCoroutine(wait());

        }

        

    }

    public void redMove(Transform dotPosition)
    {
        if(!bluered)
        {
            score++;
            gameGUI.setScore(score);

            Instantiate(redExplosion, dotPosition.position, Quaternion.identity);

            blueScript.changePosition();
            redScript.changePosition();

            generateNewMove();
        }
        else
        {
            X_GameOver.SetActive(true);
            X_GameOver.transform.position = dotPosition.position;
            //gameGUI.setScore(0);
            StartCoroutine(wait());

        }
        

    }
    
    void generateNewMove()
    {
        
        blueredInt = Random.Range(0, 2);

        colorText = Random.Range(0, 2);

        if (blueredInt == 0)
        {
            //blue
            bluered = true;
            gameGUI.setRedBlueDisplay(true,colorText);
        }
        else
        {
            //red
            bluered = false;
            gameGUI.setRedBlueDisplay(false,colorText);
        }

    }

    IEnumerator wait()
    {
        
        
        yield return new WaitForSeconds(2.0f);
        Application.LoadLevel(1);

    }



}
