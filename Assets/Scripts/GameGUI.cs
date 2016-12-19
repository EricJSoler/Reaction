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

    int readText;
    int textColor;

    public GUIStyle RedBlueStyle;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;


    public GameObject blueR_Text;
    public GameObject blueB_Text;
    public GameObject blueG_Text;
    public GameObject blueY_Text;

    public GameObject redR_Text;
    public GameObject redB_Text;
    public GameObject redG_Text;
    public GameObject redY_Text;

    public GameObject greenR_Text;
    public GameObject greenB_Text;
    public GameObject greenG_Text;
    public GameObject greenY_Text;

    public GameObject yellowR_Text;
    public GameObject yellowB_Text;
    public GameObject yellowG_Text;
    public GameObject yellowY_Text;



    public GameObject saveScore;
    private bool timeUp;
    private bool gameOver;
    private bool startGame;
    bool once = false;

    //public SpriteRenderer blurRenderer;
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
        //GUI.Label(new Rect(Screen.width - Screen.width / 6.0f, Screen.height / 38, Screen.width / 12, Screen.width / 12), "Time", TextStyle2);


        //display score number
        //GUI.Label(new Rect(Screen.width / 12, Screen.height / 15, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);


        //GUI.Label(new Rect(Screen.width / 15, Screen.height / 20, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);

        //if (roundTime < 10)
        //{
        //    GUI.Label(new Rect(Screen.width - Screen.width / 7.5f, Screen.height / 15, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        //}
        //else
        //{
        //    GUI.Label(new Rect(Screen.width - Screen.width / 6.0f, Screen.height / 15, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        //}

        if (score > 9)
        {
            GUI.Label(new Rect(Screen.width / 14.5f, Screen.height / 15, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);
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

    public void setTextDisplay(int inDot, int inTextColor)
    {
        readText = inDot;
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
        //if blue
        if (readText == 0)
        {
            //color blue
            if (textColor == 0)
            {
                blueB_Text.SetActive(true);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//color red
            else if (textColor == 1)
            {

                blueB_Text.SetActive(false);
                blueR_Text.SetActive(true);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }
            //color green
            else if (textColor == 2)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(true);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }
            //if yellow
            else if (textColor == 3)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(true);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);
            }

        }
        //if red
        else if (readText == 1)
        {
            //if red
            if (textColor == 0)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(true);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//blue color
            else if (textColor == 1)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(true);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);
            }//green color
            else if (textColor == 2)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(true);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//color yellow
            else if (textColor == 3)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(true);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);
            }
        }
        //if green
        else if(readText == 2)
        {

            //green color
            if (textColor == 0)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(true);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//blue color
            else if (textColor == 1)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(true);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);
            }//red color
            else if (textColor == 2)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(true);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//yellow color
            else if (textColor == 3)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(true);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }
        }//if yellow
        else if (readText == 3)
        {
            //green color
            if (textColor == 0)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(true);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);

            }//blue color
            else if (textColor == 1)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(true);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(false);
            }//red color
            else if (textColor == 2)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(true);
                yellowY_Text.SetActive(false);

            }//if yellow
            else if(textColor == 3)
            {
                blueB_Text.SetActive(false);
                blueR_Text.SetActive(false);
                blueG_Text.SetActive(false);
                blueY_Text.SetActive(false);

                redR_Text.SetActive(false);
                redB_Text.SetActive(false);
                redG_Text.SetActive(false);
                redY_Text.SetActive(false);

                greenR_Text.SetActive(false);
                greenB_Text.SetActive(false);
                greenG_Text.SetActive(false);
                greenY_Text.SetActive(false);

                yellowB_Text.SetActive(false);
                yellowG_Text.SetActive(false);
                yellowR_Text.SetActive(false);
                yellowY_Text.SetActive(true);
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
            //blurRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tapRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            tutRenderer.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            //tutLighttxt.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tutRighttxt.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        tutRenderer.GetComponent<Renderer>().enabled = false;
        //blurRenderer.GetComponent<Renderer>().enabled = false;
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
