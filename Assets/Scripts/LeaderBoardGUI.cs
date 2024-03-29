﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LeaderBoardGUI : MonoBehaviour {


    GameObject saveScore;
    ScoresManager scores_m;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;
    public HighScore[] HighScoreList;
    public GUIStyle btnStyle;
    bool once = false;

    float rankWidth = 10f;
    float nameWidth = 3.5f;

    void Awake()
    {
        saveScore = GameObject.Find("ScoreSave");
        scores_m = saveScore.GetComponent<ScoresManager>();
        //scores_m.DownloadHighScores();
        once = false;
    }

    // Use this for initialization
    void Start () {

        HighScoreList = scores_m.getHighScoreList();
        if(HighScoreList == null)
        {
            Debug.Log("here");
            scores_m.DownloadHighScores();
        }
    }
	
	// Update is called once per frame
	void Update () {
        TextStyle.fontSize = (int)(176.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(90.0f * (float)(Screen.width) / 1920.0f); //scale size font

        if (scores_m.arReady())
        {
            if (once == false)
            {
                HighScoreList = scores_m.getHighScoreList();
                once = true;
            }
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 18f, Screen.width / 6, Screen.width / 6), "LeaderBoards", TextStyle);

        if ((HighScoreList != null) && HighScoreList.Length == 10)
        {
            
            GUI.Label(new Rect(Screen.width / 12, Screen.height / 6.5f, Screen.width / 6, Screen.width / 6), "Rank", TextStyle2);
            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 6.5f, Screen.width / 6, Screen.width / 6), "Name", TextStyle2);
            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 6.5f, Screen.width / 6, Screen.width / 6), "Score", TextStyle2);



            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 4.8f, Screen.width / 6, Screen.width / 6), "1.",
                TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 4.8f, Screen.width / 6, Screen.width / 6), HighScoreList[0].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 4.8f, Screen.width / 6, Screen.width / 6), HighScoreList[0].score.ToString(),
                TextStyle2);






            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 3.8f, Screen.width / 6, Screen.width / 6), "2.",
                TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 3.8f, Screen.width / 6, Screen.width / 6), HighScoreList[1].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 3.8f, Screen.width / 6, Screen.width / 6), HighScoreList[1].score.ToString(),
                TextStyle2);




            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 3.1f, Screen.width / 6, Screen.width / 6), "3.",
                TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 3.1f, Screen.width / 6, Screen.width / 6), HighScoreList[2].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 3.1f, Screen.width / 6, Screen.width / 6), HighScoreList[2].score.ToString(),
                TextStyle2);



            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 2.60f, Screen.width / 6, Screen.width / 6), "4.",
                TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 2.60f, Screen.width / 6, Screen.width / 6), HighScoreList[3].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.60f, Screen.width / 6, Screen.width / 6), HighScoreList[3].score.ToString(),
                TextStyle2);




            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 2.25f, Screen.width / 6, Screen.width / 6), "5.",
                TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 2.25f, Screen.width / 6, Screen.width / 6), HighScoreList[4].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.25f, Screen.width / 6, Screen.width / 6), HighScoreList[4].score.ToString(),
                TextStyle2);



            //NEW
            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 2.00f, Screen.width / 6, Screen.width / 6), "6.",
             TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 2.00f, Screen.width / 6, Screen.width / 6), HighScoreList[5].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.00f, Screen.width / 6, Screen.width / 6), HighScoreList[5].score.ToString(),
                TextStyle2);




            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 1.80f, Screen.width / 6, Screen.width / 6), "7.",
            TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 1.80f, Screen.width / 6, Screen.width / 6), HighScoreList[6].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 1.80f, Screen.width / 6, Screen.width / 6), HighScoreList[6].score.ToString(),
                TextStyle2);




            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 1.62f, Screen.width / 6, Screen.width / 6), "8.",
            TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 1.62f, Screen.width / 6, Screen.width / 6), HighScoreList[7].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 1.62f, Screen.width / 6, Screen.width / 6), HighScoreList[7].score.ToString(),
                TextStyle2);








            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 1.50f, Screen.width / 6, Screen.width / 6), "9.",
            TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 1.50f, Screen.width / 6, Screen.width / 6), HighScoreList[8].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 1.50f, Screen.width / 6, Screen.width / 6), HighScoreList[8].score.ToString(),
                TextStyle2);







            GUI.Label(new Rect(Screen.width / rankWidth, Screen.height / 1.39f, Screen.width / 6, Screen.width / 6), "10.",
            TextStyle2);

            GUI.Label(new Rect(Screen.width / nameWidth, Screen.height / 1.39f, Screen.width / 6, Screen.width / 6), HighScoreList[9].userName,
                TextStyle2);

            GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 1.39f, Screen.width / 6, Screen.width / 6), HighScoreList[9].score.ToString(),
                TextStyle2);


        }
        else
        {
            GUI.Label(new Rect(Screen.width / 10f, Screen.height / 5.8f, Screen.width / 6, Screen.width / 6), " temporarily offline" + "\n" + "\n" + "either check your connection "+ "\n" + "or the system is under maintenence",
                TextStyle2);
        }




        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.2f, Screen.width / 2, Screen.height / 9.8f), "", btnStyle))
        {
            //scores_m.setcurScore(0);
            SceneManager.LoadScene(1);
        }


    }


}
