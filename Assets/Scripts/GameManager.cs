using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public GameObject blueDot;
    public GameObject redDot;
    public GameObject greenDot;
    public GameObject yellowDot;

    CircleScript blueScript;
    CircleScript redScript;
    CircleScript greenScript;
    CircleScript yellowScript;

    private const float COLLIDERRADIUS = 1.85f;
    GameGUI gameGUI;

    private int score;




    bool bluered = false;

    int blue = 0;
    int red = 1;
    int green = 2;
    int yellow = 3;
    int turn = 0;



    private int blueredInt = 0;
    private int colorText = 0;

    public GameObject crumpled;
    public GameObject blueExplosion;
    public GameObject redExplosion;
    public GameObject greenExplosion;
    public GameObject yellowExplosion;
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
        worldBound.BottomRightCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        worldBound.TopLeftCoordingate = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height / 1.1f));
        worldBound.TopRightCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 1.1f));

        //initialize



    }


    // Use this for initialization
    void Start()
    {


        score = 0;
        startGame = false;
        cameraRef = GameObject.Find("Main Camera").GetComponent<CameraScript>();
        crumpled = GameObject.Find("Crumpled");
        crumpled.SetActive(false);
        X_GameOver.SetActive(false);
        gameOver = false;
        blueScript = blueDot.GetComponent<CircleScript>();
        redScript = redDot.GetComponent<CircleScript>();
        greenScript = greenDot.GetComponent<CircleScript>();
        yellowScript = yellowDot.GetComponent<CircleScript>();

        gameGUI = FindObjectOfType<GameGUI>();
        gameGUI.setScore(0);

        saveScore = GameObject.Find("ScoreSave");

        generateNewMove();
        //changeDotPosition();

    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.touchCount > 0) || Input.GetMouseButtonDown(0))
        {
            startGame = true;
            gameGUI.setStart(startGame);
        }

        if (gameGUI.getTimeUp())
        {
            //gameFinished();
        }

        if (gameOver)
        {
            cameraRef.setHit(true);
        }
    }


    public void DotClicked(string color, Transform dotPosition)
    {
        gameGUI.setStart(startGame);
        if (turn == blue && color == "blue")
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);
                Instantiate(blueExplosion, dotPosition.position, Quaternion.identity);
                generateNewMove();
                // changeDotPosition();
            }
        }
        else if (turn == red && color == "red")
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);
                Instantiate(redExplosion, dotPosition.position, Quaternion.identity);
                generateNewMove();
                //changeDotPosition();
            }
        }
        else if (turn == green && color == "green")
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);
                Instantiate(greenExplosion, dotPosition.position, Quaternion.identity);
                generateNewMove();
                // changeDotPosition();
            }
        }
        else if (turn == yellow && color == "yellow")
        {
            if (!gameOver)
            {
                score++;
                gameGUI.setScore(score);
                Instantiate(yellowExplosion, dotPosition.position, Quaternion.identity);
                generateNewMove();
                // changeDotPosition();
            }
        }
        else
        {
            gameOver = true;
            this.FreezeAllDots();
            X_GameOver.SetActive(true);
            //X_GameOver.transform.position = dotPosition.position;
            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

            StartCoroutine(wait());
        }
    }

    public void FreezeAllDots()
    {
        blueScript.Speed = 0f;
        redScript.Speed = 0f;
        greenScript.Speed = 0f;
        yellowScript.Speed = 0f;
    }




    public void generateNewMove()
    {

        turn = Random.Range(0, 4);
        colorText = Random.Range(0, 4);

        if (turn == 0)
        {
            //blue
            turn = 0;
            gameGUI.setTextDisplay(0, colorText);
        }
        else if (turn == 1)
        {
            //red
            turn = 1;
            gameGUI.setTextDisplay(1, colorText);
        }
        else if (turn == 2)
        {
            //green
            turn = 2;
            gameGUI.setTextDisplay(2, colorText);
        }
        else
        {
            //yellow
            turn = 3;
            gameGUI.setTextDisplay(3, colorText);
        }

        this.SpawnAllInMiddle();

    }

    public void SpawnAllInMiddle()
    {
        Vector2 midPoint = Camera.main.ScreenToWorldPoint(new Vector2((Screen.width / 2), (Screen.height / 1.1f) / 2));
        redScript.updatePosition(midPoint);
        blueScript.updatePosition(midPoint);
        greenScript.updatePosition(midPoint);
        yellowScript.updatePosition(midPoint);

        float speedAdj = redScript.Speed * .04f;

        this.SendDotsInRandomDirectinonsAwayFromEachother();

        redScript.Speed += speedAdj;
        blueScript.Speed += speedAdj;
        greenScript.Speed += speedAdj;
        yellowScript.Speed += speedAdj;

        Debug.Log(redScript.Speed);
    }

    public void SendDotsInRandomDirectinonsAwayFromEachother()
    {
        int combo = Random.Range(0, 17);
        //int combo = 0;

        //Cwxr
        Vector2 topLeft = new Vector2(-1, 1);
        Vector2 topRight = new Vector2(1, 1);
        Vector2 bottomLeft = new Vector2(-1, -1);
        Vector2 bottomRight = new Vector2(1, -1);

        Vector2 top = new Vector2(0, 1);
        Vector2 right = new Vector2(1, 0);
        Vector2 bottom = new Vector2(0, -1);
        Vector2 left = new Vector2(-1, 0);

        //  Vector2 rotationShift = new Vector2(-1f, 0f);



        int flip = Random.Range(0, 1);
        
        // blueScript.SetDirection(topLeft + rotationShift); //tl
        if (flip == 0)
        {
            #region choosingDiagnol to go
            switch (combo)
            {
                case 0:
                    blueScript.SetDirection(topLeft); //tl
                    redScript.SetDirection(topRight); //tr
                    greenScript.SetDirection(bottomLeft); //br
                    break;
                case 1:
                    blueScript.SetDirection(topLeft); //tl
                    redScript.SetDirection(topRight);
                    greenScript.SetDirection(bottomRight);
                    break;
                case 2:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(bottomRight);
                    greenScript.SetDirection(bottomLeft);
                    break;
                case 3:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(bottomLeft);
                    greenScript.SetDirection(bottomRight);
                    break;
                case 4:
                    blueScript.SetDirection(topLeft);
                    redScript.SetDirection(bottomLeft);
                    greenScript.SetDirection(topRight);
                    break;
                case 5:
                    blueScript.SetDirection(topLeft);
                    redScript.SetDirection(bottomRight);
                    greenScript.SetDirection(topRight);
                    break;
                case 6:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(bottomLeft);
                    break;
                case 7:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(bottomRight);
                    break;
                case 8:
                    blueScript.SetDirection(bottomRight);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(bottomLeft);
                    break;
                case 9:
                    blueScript.SetDirection(bottomLeft);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(bottomRight);
                    break;
                case 10:
                    blueScript.SetDirection(bottomLeft);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(bottomRight);
                    break;
                case 11:
                    blueScript.SetDirection(bottomLeft);
                    redScript.SetDirection(topLeft);
                    greenScript.SetDirection(topRight);
                    break;
                case 12:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(bottomRight);
                    greenScript.SetDirection(topLeft);
                    break;
                case 13:
                    blueScript.SetDirection(topRight);
                    redScript.SetDirection(bottomLeft);
                    greenScript.SetDirection(topLeft);
                    break;
                case 14:
                    blueScript.SetDirection(bottomLeft);
                    redScript.SetDirection(topRight);
                    greenScript.SetDirection(topLeft);
                    break;
                case 15:
                    blueScript.SetDirection(bottomRight);
                    redScript.SetDirection(topRight);
                    greenScript.SetDirection(topLeft);
                    break;
                case 16:
                    blueScript.SetDirection(bottomRight);
                    redScript.SetDirection(bottomLeft);
                    greenScript.SetDirection(topLeft);
                    break;
                case 17:
                    blueScript.SetDirection(bottomLeft);
                    redScript.SetDirection(bottomRight);
                    greenScript.SetDirection(topLeft);
                    break;
                default:
                    Debug.Log("You fucked up");
                    break;
            }
            #endregion
        }
        else
        {

            switch (combo)
            {
                case 0:
                    blueScript.SetDirection(top); //tl
                    redScript.SetDirection(right); //tr
                    greenScript.SetDirection(bottom); //br
                    break;
                case 1:
                    blueScript.SetDirection(top); //tl
                    redScript.SetDirection(right);
                    greenScript.SetDirection(left);
                    break;
                case 2:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(left);
                    greenScript.SetDirection(bottom);
                    break;
                case 3:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(bottom);
                    greenScript.SetDirection(left);
                    break;
                case 4:
                    blueScript.SetDirection(top);
                    redScript.SetDirection(bottom);
                    greenScript.SetDirection(right);
                    break;
                case 5:
                    blueScript.SetDirection(top);
                    redScript.SetDirection(left);
                    greenScript.SetDirection(right);
                    break;
                case 6:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(bottom);
                    break;
                case 7:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(left);
                    break;
                case 8:
                    blueScript.SetDirection(left);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(bottom);
                    break;
                case 9:
                    blueScript.SetDirection(bottom);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(left);
                    break;
                case 10:
                    blueScript.SetDirection(bottom);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(left);
                    break;
                case 11:
                    blueScript.SetDirection(bottom);
                    redScript.SetDirection(top);
                    greenScript.SetDirection(right);
                    break;
                case 12:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(left);
                    greenScript.SetDirection(top);
                    break;
                case 13:
                    blueScript.SetDirection(right);
                    redScript.SetDirection(bottom);
                    greenScript.SetDirection(top);
                    break;
                case 14:
                    blueScript.SetDirection(bottom);
                    redScript.SetDirection(right);
                    greenScript.SetDirection(top);
                    break;
                case 15:
                    blueScript.SetDirection(left);
                    redScript.SetDirection(right);
                    greenScript.SetDirection(top);
                    break;
                case 16:
                    blueScript.SetDirection(left);
                    redScript.SetDirection(bottom);
                    greenScript.SetDirection(top);
                    break;
                case 17:
                    blueScript.SetDirection(bottom);
                    redScript.SetDirection(left);
                    greenScript.SetDirection(top);
                    break;
                default:
                    break;
            }
        }
    }


    // deprecated
    //bool doTheseObjectsOverlap(float objectsRadius, Vector2 a, Vector2 b)
    //{
    //    float distance = Vector3.Distance(a, b);

    //    if (distance < COLLIDERRADIUS)
    //    {
    //        //changeDotPosition();
    //    }

    //    return false;
    //}

    //private Vector2 createValidPositionInGameBoard(float objectsRadius)
    //{
    //    Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height / 1.4f)));
    //    Vector2 btmRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // i think is actually top right musta been out of it when i did this
    //    Vector2 topLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)); // i think this is actaullly bottom left
    //    float x = Mathf.Clamp(temp.x, topLeftCorner.x + objectsRadius, btmRightCorner.x - objectsRadius);
    //    float y = Mathf.Clamp(temp.y, topLeftCorner.y + objectsRadius, btmRightCorner.y - objectsRadius);

    //    return new Vector2(x, y);
    //}

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

    public void EscapedScreen(string color)
    {
        //#if DEBUG
        //        //Debug.Log(color);
        //        //this.generateNewMove();
        //        //return;
        //#endif
        if (turn == blue && color == "blue")
        {
            gameFinished();
        }
        else if (turn == red && color == "red")
        {
            gameFinished();
        }
        else if (turn == green && color == "green")
        {
            gameFinished();
        }
    }


    //    if (turn == blue)
    //    {
    //        if (!gameOver)
    //        {
    //            score++;
    //            gameGUI.setScore(score);


    //            Instantiate(blueExplosion, dotPosition.position, Quaternion.identity);

    //            //blueScript.changePosition();
    //            //redScript.changePosition();

    //            generateNewMove();
    //            changeDotPosition();
    //        }
    //    }
    //    else
    //    {
    //        gameOver = true;
    //        X_GameOver.SetActive(true);
    //        //X_GameOver.transform.position = dotPosition.position;
    //        X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

    //        StartCoroutine(wait());
    //    }
    //}


    ////deprecated
    //    public void blueMove(Transform dotPosition)
    //    {
    //        gameGUI.setStart(startGame);
    //        if (turn == blue)
    //        {
    //            if (!gameOver)
    //            {
    //                score++;
    //                gameGUI.setScore(score);


    //                Instantiate(blueExplosion, dotPosition.position, Quaternion.identity);

    //                //blueScript.changePosition();
    //                //redScript.changePosition();

    //                generateNewMove();
    //                changeDotPosition();
    //            }
    //        }
    //        else
    //        {
    //            gameOver = true;
    //            X_GameOver.SetActive(true);
    //            //X_GameOver.transform.position = dotPosition.position;
    //            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

    //            StartCoroutine(wait());
    //        }
    //    }

    ////deprecated
    //    public void redMove(Transform dotPosition)
    //    {
    //        gameGUI.setStart(startGame);
    //        if (turn == red)
    //        {
    //            if (!gameOver)
    //            {
    //                score++;
    //                gameGUI.setScore(score);


    //                Instantiate(redExplosion, dotPosition.position, Quaternion.identity);

    //                //blueScript.changePosition();
    //                //redScript.changePosition();



    //                generateNewMove();
    //                changeDotPosition();
    //            }
    //        }
    //        else
    //        {
    //            gameOver = true;
    //            X_GameOver.SetActive(true);
    //            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);
    //            //gameGUI.setScore(0);
    //            StartCoroutine(wait());
    //        }
    //    }

    ////deprecated
    //    public void greenMove(Transform dotPosition)
    //    {
    //        gameGUI.setStart(startGame);
    //        if (turn == green)
    //        {
    //            if (!gameOver)
    //            {
    //                score++;
    //                gameGUI.setScore(score);


    //                Instantiate(greenExplosion, dotPosition.position, Quaternion.identity);

    //                //blueScript.changePosition();
    //                //redScript.changePosition();

    //                generateNewMove();
    //                changeDotPosition();
    //            }
    //        }
    //        else
    //        {
    //            gameOver = true;
    //            X_GameOver.SetActive(true);
    //            //X_GameOver.transform.position = dotPosition.position;
    //            X_GameOver.transform.position = new Vector3(dotPosition.position.x, dotPosition.position.y, -5f);

    //            StartCoroutine(wait());
    //        }
    //    }



}