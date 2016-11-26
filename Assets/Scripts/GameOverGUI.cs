using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour
{

    public Texture btnTexture;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;
    
    public GUIStyle btnStyle;
    public GUIStyle btnStyle2;
    public GUIStyle btnStyle3;
    public GameObject saveScore;
    ScoresManager scores_m;
    bool once = false;
    public HighScore[] HighScoreList;

    int curScore = 0;

    void Awake()
    {
        saveScore = GameObject.Find("ScoreSave");
        scores_m = saveScore.GetComponent<ScoresManager>();
        curScore = scores_m.getcurScore();
        once = false;

    }
    
    // Use this for initialization
    void Start()
    {
        

        if (curScore > scores_m.getHighScore())
        {
            scores_m.setHighScore(curScore);
            
        }
        scores_m.AddNewLeadScore(scores_m.getUsername(), scores_m.getcurScore());
        //scores_m.DownloadHighScores();

    }

    // Update is called once per frame
    void Update()
    {

        TextStyle.fontSize = (int)(160.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(80.0f * (float)(Screen.width) / 1920.0f); //scale size font

        if (scores_m.arReady())
        {        
             HighScoreList = scores_m.getHighScoreList();
        }
        
    }

    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 5.25f, Screen.width / 6, Screen.width / 6), "score: ", TextStyle);
        GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 5.25f, Screen.width / 6, Screen.width / 6), curScore.ToString(), TextStyle);

        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 3.5f, Screen.width / 6, Screen.width / 6), "best: ", TextStyle);

        GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 3.5f, Screen.width / 6, Screen.width / 6), 
            scores_m.getHighScore().ToString()
            , TextStyle);

        GUI.Label(new Rect(Screen.width / 8f, Screen.height / 2.63f, Screen.width / 6, Screen.width / 6), "world record: ", TextStyle);

        if ((HighScoreList != null))
        {
            GUI.Label(new Rect(Screen.width / 1.35f, Screen.height / 2.63f, Screen.width / 6, Screen.width / 6),
                HighScoreList[0].score.ToString()
                , TextStyle);
        }
        //GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 2.8f, Screen.width / 6, Screen.width / 6), "Rank: ", TextStyle);


        //GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 1.3f, Screen.width / 6, Screen.width / 6), "name test: " + scores_m.getUsername().ToString(), TextStyle2);

        //GUI.Label(new Rect(10, 10, 100, 40), "GameOver");
        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle))
        {
            scores_m.setcurScore(0);
            SceneManager.LoadScene(1);
        }

        
        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.58f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle2))
        {
            scores_m.setcurScore(0);
            SceneManager.LoadScene(0);
        }

        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.30f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle3))
        {
            //scores_m.setcurScore(0);
            SceneManager.LoadScene(3);
        }


    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);

    }

}