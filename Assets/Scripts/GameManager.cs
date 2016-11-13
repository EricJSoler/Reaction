using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject blueDot;
    public GameObject redDot;
    CircleScript blueScript;
    RedCircleScript redScript;


    private const float COLLIDERRADIUS = 1.85f;
    GameGUI gameGUI;

    private int score;
    bool bluered = false;
    private int blueredInt = 0;
    private int colorText = 0;


    public GameObject blueExplosion;
    public GameObject redExplosion;
    public GameObject X_GameOver;
    public static GameObject saveScore;
    bool gameOver = false;
    CameraScript cameraRef;
    



    Transform red;
    Transform blue;

    void Awake()
    {

   
         
            //initialize
        
    }


    // Use this for initialization
    void Start () {
        score = 0;
        cameraRef = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        X_GameOver.SetActive(false);
        gameOver = false;
        blueScript = blueDot.GetComponent<CircleScript>();
        redScript = redDot.GetComponent<RedCircleScript>();
        gameGUI = FindObjectOfType<GameGUI>();
        gameGUI.setScore(0);
        generateNewMove();

        saveScore = GameObject.Find("ScoreSave");


    }
	
	// Update is called once per frame
	void Update () {

        while (redScript.getCollision())
        {
            //changeDotPosition();
        }


        if (gameGUI.getTimeUp())
        {
            gameFinished();
        }


        if (gameOver)
        {
            cameraRef.setHit(true);
        }


    
	}

    public void blueMove(Transform dotPosition)
    {
        if(bluered)
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);


                Instantiate(blueExplosion, dotPosition.position, Quaternion.identity);

                //blueScript.changePosition();
                //redScript.changePosition();

                generateNewMove();
                changeDotPosition();
            }
        }
        else
        {
            gameOver = true;
            X_GameOver.SetActive(true);
            X_GameOver.transform.position = dotPosition.position;
            
            StartCoroutine(wait());

        }

        

    }

    public void redMove(Transform dotPosition)
    {
        if(!bluered)
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);

                if (!gameOver)
                    Instantiate(redExplosion, dotPosition.position, Quaternion.identity);

                //blueScript.changePosition();
                //redScript.changePosition();



                generateNewMove();
                changeDotPosition();
            }
        }
        else
        {
            gameOver = true;
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

    void changeDotPosition()
    {
        //blueScript.changePosition();
        //redScript.changePosition();   
        Vector2 bluePosition = createValidPositionInGameBoard(COLLIDERRADIUS);
        Vector2 redPosition = createValidPositionInGameBoard(COLLIDERRADIUS);
        blueScript.updatePosition(bluePosition);
        redScript.updatePosition(redPosition);
        doTheseObjectsOverlap(COLLIDERRADIUS, bluePosition, redPosition);
        
    }

    bool doTheseObjectsOverlap(float objectsRadius, Vector2 a, Vector2 b)
    {

        float distance = Vector3.Distance(a, b);

        if (distance < COLLIDERRADIUS)
        {
            //Debug.Log("Overlapping");
            //Debug.Log(distance);
            changeDotPosition();
        }

            return false;
        //bool above = false;
        //bool right = false;
        //if (a.x < b.x)
        //{
        //    right = true;
        //}
        //if( a.y < b.y )
        //{
        //    above = true;
        //}

        //if(right && b.x - a.x <= objectsRadius * 2) //overlapping push myself right by that amount
        //{
        //    Debug.Log("Overlapping On right");
        //    return true;
        //}
        //else if( a.x - b.x <= objectsRadius * 2)
        //{
        //    Debug.Log("Overlapping On Left");
        //    return true;
        //}
        //if(above && b.y - a.y <= objectsRadius * 2)//overlapping push myself top by that amount
        //{
        //    Debug.Log("Overlapping by above");
        //    return true;
        //}
        //else if (a.y - b.y <= objectsRadius * 2)
        //{
        //    Debug.Log("Overlapping by below");
        //    return true;
        //}
        //return false;
    }

    //private Vector2 recalculateVectorsForOverlappingObjects(float objectsRadius, Vector2 a, Vector2 b)
    //{
    //    if (a.x < b.x)
    //    {
    //        if (redPosition.y <= bluePosition.y)
    //        {
    //            float
    //        }
    //        else
    //        {

    //        }

    //    }
    //    else
    //    {

    //    }

    //}
    private Vector2 createValidPositionInGameBoard(float objectsRadius)
    {
        Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
        Vector2 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        float x = Mathf.Clamp(temp.x, bottomLeftCorner.x + objectsRadius, topRightCorner.x - objectsRadius);
        float y = Mathf.Clamp(temp.y, bottomLeftCorner.y + objectsRadius, topRightCorner.y - objectsRadius);

        return new Vector2(x, y);
    }

    IEnumerator wait()
    {

        gameGUI.setGameOver(true);
        yield return new WaitForSeconds(2.0f);
        gameFinished();

    }


    public void gameFinished()
    {
        
        //save score, then load next scene
        saveScore.GetComponent<ScoresManager>().setcurScore(gameGUI.getScore());
        Application.LoadLevel(1);
    }


}
