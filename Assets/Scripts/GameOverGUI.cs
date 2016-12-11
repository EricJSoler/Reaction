using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

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

    int frequencyOfAdds = 2;

    void Awake()
    {
        saveScore = GameObject.Find("ScoreSave");
        scores_m = saveScore.GetComponent<ScoresManager>();
        curScore = scores_m.getcurScore();
        once = false;

        if (scores_m.SinceAdd % frequencyOfAdds == 0)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
        }
        scores_m.SinceAdd++;

    }
    
    // Use this for initialization
    void Start()
    {
        
        //save high score to device
        if (curScore > scores_m.getHighScore())
        {
            scores_m.setHighScore(curScore);
            
        }
        saveScoresToLeaderBoard();

        //scores_m.DownloadHighScores();

    }

    // Update is called once per frame
    void Update()
    {

        TextStyle.fontSize = (int)(160.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(100.0f * (float)(Screen.width) / 1920.0f); //scale size font

        if (scores_m.arReady())
        {        
             HighScoreList = scores_m.getHighScoreList();
        }

        
        
    }

    public void saveScoresToLeaderBoard()
    {
        //save scores to leaderBoard
            
        scores_m.AddNewLeadScore(scores_m.getUsername(), scores_m.getcurScore());
        Debug.Log("offline score " + scores_m.getOfflineScore().ToString());
        //save your highest score while offline
        if (scores_m.getOfflineScore() > 0)
        {
            Debug.Log("OFF call");
            scores_m.AddNewLeadScore(scores_m.getUsername(), scores_m.getOfflineScore());
            scores_m.setOfflineScoreToZero();
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 5.25f, Screen.width / 6, Screen.width / 6), "Score: ", TextStyle);
        GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 5.25f, Screen.width / 6, Screen.width / 6), curScore.ToString(), TextStyle);

        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 3.5f, Screen.width / 6, Screen.width / 6), "Best: ", TextStyle);

        GUI.Label(new Rect(Screen.width / 1.8f, Screen.height / 3.5f, Screen.width / 6, Screen.width / 6), 
            scores_m.getHighScore().ToString()
            , TextStyle);

        GUI.Label(new Rect(Screen.width / 8f, Screen.height / 2.13f, Screen.width / 6, Screen.width / 6), "World Record: ", TextStyle2);

        GUI.Label(new Rect(Screen.width / 8f, Screen.height / 2.43f, Screen.width / 6, Screen.width / 6), "Current Champ: ", TextStyle2);


        if ((HighScoreList != null))
        {
            GUI.Label(new Rect(Screen.width / 1.55f, Screen.height / 2.13f, Screen.width / 6, Screen.width / 6),
                HighScoreList[0].score.ToString()
                , TextStyle);

            GUI.Label(new Rect(Screen.width / 1.55f, Screen.height / 2.43f, Screen.width / 6, Screen.width / 6),
                HighScoreList[0].userName.ToString()
                , TextStyle2);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 1.55f, Screen.height / 2.13f, Screen.width / 6, Screen.width / 6),
                "-"
                , TextStyle);

            GUI.Label(new Rect(Screen.width / 1.55f, Screen.height / 2.43f, Screen.width / 6, Screen.width / 6),
                "-"
                , TextStyle2);
        }
        //GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 2.8f, Screen.width / 6, Screen.width / 6), "Rank: ", TextStyle);


        //GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 1.3f, Screen.width / 6, Screen.width / 6), "name test: " + scores_m.getUsername().ToString(), TextStyle2);

        //GUI.Label(new Rect(10, 10, 100, 40), "GameOver");
        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.73f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle))
        {
            scores_m.setcurScore(0);
            SceneManager.LoadScene(2);
        }

        
        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.45f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle2))
        {
            scores_m.setcurScore(0);
            SceneManager.LoadScene(1);
        }

        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.245f, Screen.width / 2, Screen.height / 10.2f), "", btnStyle3))
        {
            //scores_m.setcurScore(0);
            SceneManager.LoadScene(4);
        }


    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);

    }

}