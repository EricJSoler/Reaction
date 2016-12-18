using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject blueDot;
    public GameObject redDot;
    public GameObject greenDot;
    CircleScript blueScript;
    RedCircleScript redScript;
    GreenCircleScript greenScript;

    private const float COLLIDERRADIUS = 1.85f;
    GameGUI gameGUI;

    private int score;



    bool bluered = false;

    int blue = 0;
    int red = 1;
    int green = 2;
    int turn = 0;



    private int blueredInt = 0;
    private int colorText = 0;

    public GameObject crumpled;
    public GameObject blueExplosion;
    public GameObject redExplosion;
    public GameObject greenExplosion;
    public GameObject X_GameOver;
    public static GameObject saveScore;
    bool gameOver = false;
    CameraScript cameraRef;

    public Animation anim;


    bool startGame = false;

    public class WorldBound
    {
        public Vector2 BottomLeftCoordinate = new Vector2();
        public Vector2 BottomRightCoordinate = new Vector2();
        public Vector2 TopRightCoordinate = new Vector2();
        public Vector2 TopLeftCoordingate = new Vector2();

        public bool ObjectInsideWorldBound(Vector2 loc, float radius)
        {
            if (loc.x - radius > BottomRightCoordinate.x)
                return false;
            if (loc.x + radius < BottomLeftCoordinate.x)
                return false;
            if (loc.y + radius < BottomLeftCoordinate.y) 
                return false;
            if (loc.y - radius > TopLeftCoordingate.y)
                return false;

            return true;
        }
    }

    public WorldBound worldBound = new WorldBound();
    


    void Awake()
    {
        worldBound.BottomLeftCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        worldBound.BottomRightCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)); 
        worldBound.TopLeftCoordingate = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 1.1f));
        worldBound.TopRightCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 1.1f));

        //initialize



    }


    // Use this for initialization
    void Start () {


        score = 0;
        startGame = false;
        cameraRef = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        crumpled = GameObject.Find("Crumpled");
        crumpled.SetActive(false);
        X_GameOver.SetActive(false);
        gameOver = false;
        blueScript = blueDot.GetComponent<CircleScript>();
        redScript = redDot.GetComponent<RedCircleScript>();
        greenScript = greenDot.GetComponent<GreenCircleScript>();


        gameGUI = FindObjectOfType<GameGUI>();
        gameGUI.setScore(0);

        saveScore = GameObject.Find("ScoreSave");

        generateNewMove();
        changeDotPosition();

    }

    // Update is called once per frame
    void Update () {

        while (redScript.getCollision())
        {
            //changeDotPosition();
        }

        if ((Input.touchCount > 0) || Input.GetMouseButtonDown(0))
        {
            startGame = true;
            gameGUI.setStart(startGame);
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
        gameGUI.setStart(startGame);
        if (turn == blue)
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
            //X_GameOver.transform.position = dotPosition.position;
            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

            StartCoroutine(wait());
        }
    }

    public void redMove(Transform dotPosition)
    {
        gameGUI.setStart(startGame);
        if (turn == red)
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);

                
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
            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);
            //gameGUI.setScore(0);
            StartCoroutine(wait());
        }
    }


    public void greenMove(Transform dotPosition)
    {
        gameGUI.setStart(startGame);
        if (turn == green)
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);


                Instantiate(greenExplosion, dotPosition.position, Quaternion.identity);

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
            //X_GameOver.transform.position = dotPosition.position;
            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

            StartCoroutine(wait());
        }
    }



















    public void generateNewMove()
    {
        
        turn = Random.Range(0, 3);
        colorText = Random.Range(0, 3);

        if (turn == 0)
        {
            //blue
            turn = 0;
            gameGUI.setTextDisplay(0, colorText);
        }
        else if(turn == 1)
        {
            //red
            turn = 1;
            gameGUI.setTextDisplay(1, colorText);
        }
        else
        {
            //green
            turn = 2;
            gameGUI.setTextDisplay(2, colorText);
        }

    }

    public void changeDotPosition()
    {
        Vector2 bluePosition = createValidPositionInGameBoard(blueScript.radius);
        Vector2 redPosition = createValidPositionInGameBoard(redScript.radius);
        Vector2 greenPosition = createValidPositionInGameBoard(greenScript.radius);
        blueScript.updatePosition(bluePosition);
        redScript.updatePosition(redPosition);
        greenScript.updatePosition(greenPosition);


        //doTheseObjectsOverlap(blueScript.radius, bluePosition, redPosition); // need to update if objects have different radiuses
        
    }

    bool doTheseObjectsOverlap(float objectsRadius, Vector2 a, Vector2 b)
    {
        float distance = Vector3.Distance(a, b);

        if (distance < COLLIDERRADIUS)
        {
            changeDotPosition();
        }

            return false;
    }

    private Vector2 createValidPositionInGameBoard(float objectsRadius)
    {
        Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height /1.4f)));
        Vector2 btmRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // i think is actually top right musta been out of it when i did this
        Vector2 topLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); // i think this is actaullly bottom left
        float x = Mathf.Clamp(temp.x, topLeftCorner.x + objectsRadius, btmRightCorner.x - objectsRadius);
        float y = Mathf.Clamp(temp.y, topLeftCorner.y + objectsRadius, btmRightCorner.y - objectsRadius);

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
        Application.LoadLevel(3);
    }


}
