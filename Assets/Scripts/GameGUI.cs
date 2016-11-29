using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

    float time = 30.0f;
    float displayTime = 0.0f;
    float roundTime = 0.0f;
    float multTime = 0.0f;

    public static int score;

    int TextWidth = 45;

    public float duration = 5.0F;

    bool redblueGUI;
    int textColor;

    public GUIStyle RedBlueStyle;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;

    public GameObject redR_Text;
    public GameObject redB_Text;
    public GameObject blueR_Text;
    public GameObject blueB_Text;

    public GameObject saveScore;
    private bool timeUp;
    private bool gameOver;
    private bool startGame;
    bool once = false;

    public SpriteRenderer blurRenderer;
    public SpriteRenderer tapRenderer;
    public SpriteRenderer tutRenderer;

    public SpriteRenderer tutLighttxt;
    public SpriteRenderer tutRighttxt;

    // Use this for initialization
    void Start () {

        timeUp = false;
        gameOver = false;
        startGame = false;
        once = false;

        textDisplay();
        time = 30.0f;
        roundTime = 30;

    }
	
	// Update is called once per frame
	void Update () {

        TextStyle.fontSize = (int)(130.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(70.0f * (float)(Screen.width) / 1920.0f); //scale size font

        if (!gameOver && startGame)
        {
            time -= Time.deltaTime;
            //multTime = time * 10;
            roundTime = (int)time;
            displayTime = roundTime / 10;

            if (roundTime <= 0.0f)
            {
                timeUp = true;
                //Application.LoadLevel(1);
            }
        }

      

        float t = Mathf.PingPong(Time.time, duration);
        //fadeInTut();
    }

    void OnGUI()
    {
        if (startGame)
        {
            if (!once)
            {
                fadeOut();
                once = true;
            }
            //GUI.Label(new Rect(Screen.width / 4.8f, Screen.height / 2, Screen.width / 12, Screen.width / 12), "Tap to start!", TextStyle);
        }

        //score + time text display
        //score
        GUI.Label(new Rect(Screen.width / 15, Screen.height / 38, Screen.width / 12, Screen.width / 12), "Score", TextStyle2);
        //time
        GUI.Label(new Rect(Screen.width - Screen.width / 6.0f, Screen.height / 38, Screen.width / 12, Screen.width / 12), "Time", TextStyle2);


        //display score number
        //GUI.Label(new Rect(Screen.width / 12, Screen.height / 15, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);


        //GUI.Label(new Rect(Screen.width / 15, Screen.height / 20, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);

        if (roundTime < 10)
        {
            GUI.Label(new Rect(Screen.width - Screen.width / 7.3f, Screen.height / 15, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width - Screen.width / 6.0f, Screen.height / 15, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        }

        if (score > 9)
        {
            GUI.Label(new Rect(Screen.width / 14, Screen.height / 15, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 12, Screen.height / 15, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);
        }




        textDisplay();

    }

    public void setStart(bool inStart)
    {
        startGame = inStart;
    }

    public void setScore(int inScore)
    {
        score = inScore;
    }

    public int getScore()
    {
        return score;
    }

    public void setRedBlueDisplay(bool inDot, int inTextColor)
    {
        redblueGUI = inDot;
        textColor = inTextColor;
    }

    public bool getTimeUp()
    {
        return timeUp;
    }

    public void setGameOver(bool inBool)
    {
        gameOver = inBool;
    }

    public void textDisplay()
    {
        if (redblueGUI)
        {
            //if blue
            if (textColor == 0)
            {
                //RedBlueStyle.normal.textColor = Color.blue;
                //GUI.Label(new Rect(50, 50, TextWidth, 40), "Blue", RedBlueStyle);
                //Debug.Log("blue, blue");
                blueB_Text.SetActive(true);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                //blueB_Text.SetActive(false);
            }
            else
            {
                //RedBlueStyle.normal.textColor = Color.red;
                //GUI.Label(new Rect(50, 50, TextWidth, 40), "Blue", RedBlueStyle);
                //Debug.Log("blue, red");
                blueR_Text.SetActive(true);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                //blueR_Text.SetActive(false);
                blueB_Text.SetActive(false);
            }

        }
        else
        {
            //if red
            if (textColor == 0)
            {
                //RedBlueStyle.normal.textColor = Color.blue;
                //GUI.Label(new Rect(50, 50, TextWidth, 40), "Red", RedBlueStyle);
                //Debug.Log("red, blue");
                redB_Text.SetActive(true);

                redR_Text.SetActive(false);
                //redB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueB_Text.SetActive(false);
            }
            else
            {
                //RedBlueStyle.normal.textColor = Color.red;
                //GUI.Label(new Rect(50, 50, TextWidth, 40), "Red", RedBlueStyle);
                //Debug.Log("red, red");

                redR_Text.SetActive(true);

                //redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueB_Text.SetActive(false);
            }
        }
    }


    public void fadeOut()
    {
        StartCoroutine(fadeOutTxt());
        
    }

    public void fadeInTut()
    {
        StartCoroutine(fadeInTxt());

    }

    private IEnumerator fadeOutTxt()
    {
        float duration = .4f;
        float currentTime = 0f;

        float oldAlpha = 1.0f;
        float finalAlpha = 0.0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            blurRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tapRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            tutRenderer.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            //tutLighttxt.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tutRighttxt.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        tutRenderer.GetComponent<Renderer>().enabled = false;
        blurRenderer.GetComponent<Renderer>().enabled = false;
        //tutLighttxt.GetComponent<Renderer>().enabled = false;
        //tutRighttxt.GetComponent<Renderer>().enabled = false;
        yield break;
    }

    private IEnumerator fadeInTxt()
    {
        float duration = 1.06f;
        float currentTime = 0f;

        float oldAlpha = 0.0f;
        float finalAlpha = 1.0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            //tutLighttxt.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tutRighttxt.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
      
        yield break;
    }
}
