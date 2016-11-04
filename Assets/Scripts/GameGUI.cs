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

    public GameObject redR_Text;
    public GameObject redB_Text;
    public GameObject blueR_Text;
    public GameObject blueB_Text;

    


    // Use this for initialization
    void Start () {
        
        textDisplay();

        
    }
	
	// Update is called once per frame
	void Update () {

        TextStyle.fontSize = (int)(180.0f * (float)(Screen.width) / 1920.0f); //scale size font

        time -= Time.deltaTime;
        //multTime = time * 10;
        roundTime = (int) time;
        displayTime = roundTime / 10;

        if(roundTime <= 0.0f)
        {
            Application.LoadLevel(1);
        }

        float t = Mathf.PingPong(Time.time, duration);
        
    }

    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 15, Screen.height / 20, Screen.width / 12, Screen.width / 12), score.ToString(), TextStyle);

        if (roundTime < 10)
        {
            GUI.Label(new Rect(Screen.width - Screen.width / 7.3f, Screen.height / 20, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        }
        else
        {
            GUI.Label(new Rect(Screen.width - Screen.width / 6.0f, Screen.height / 20, Screen.width / 12, Screen.width / 12), roundTime.ToString(), TextStyle);
        }
        textDisplay();

    }

    public void setScore(int inScore)
    {
        score = inScore;
    }

    public void setRedBlueDisplay(bool inDot, int inTextColor)
    {
        redblueGUI = inDot;
        textColor = inTextColor;
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


}
