using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LeaderBoardGUI : MonoBehaviour {


    GameObject saveScore;
    ScoresManager scores_m;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;
    public HighScore[] HighScoreList;
    public GUIStyle btnStyle;

    void Awake()
    {
        saveScore = GameObject.Find("ScoreSave");
        scores_m = saveScore.GetComponent<ScoresManager>();
        //scores_m.DownloadHighScores();

    }

    // Use this for initialization
    void Start () {

        HighScoreList = scores_m.getHighScoreList();
    }
	
	// Update is called once per frame
	void Update () {
        TextStyle.fontSize = (int)(176.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(136.0f * (float)(Screen.width) / 1920.0f); //scale size font
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 14f, Screen.width / 6, Screen.width / 6), "LeaderBoards", TextStyle);


        GUI.Label(new Rect(Screen.width / 8f, Screen.height / 6.5f, Screen.width / 6, Screen.width / 6), "Rank    " +
            "Name" + "      " + "Score",
            TextStyle2);

        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 5f, Screen.width / 6, Screen.width / 6), "1.     " +
            HighScoreList[0].userName,
            TextStyle2);
        GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 5f, Screen.width / 6, Screen.width / 6), HighScoreList[0].score.ToString(),
            TextStyle2);






        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 3.8f, Screen.width / 6, Screen.width / 6), "2.     " +
            HighScoreList[1].userName,
            TextStyle2);
        GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 3.8f, Screen.width / 6, Screen.width / 6), HighScoreList[1].score.ToString(),
            TextStyle2);




        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 3.1f, Screen.width / 6, Screen.width / 6), "3.     " +
            HighScoreList[2].userName,
            TextStyle2);
        GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 3.1f, Screen.width / 6, Screen.width / 6), HighScoreList[2].score.ToString(),
            TextStyle2);



        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 2.60f, Screen.width / 6, Screen.width / 6), "4.     " +
            HighScoreList[3].userName,
            TextStyle2);
        GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.60f, Screen.width / 6, Screen.width / 6), HighScoreList[3].score.ToString(),
            TextStyle2);


        GUI.Label(new Rect(Screen.width / 5.5f, Screen.height / 2.25f, Screen.width / 6, Screen.width / 6), "5.     " +
            HighScoreList[4].userName,
            TextStyle2);

        GUI.Label(new Rect(Screen.width / 1.3f, Screen.height / 2.25f, Screen.width / 6, Screen.width / 6), HighScoreList[4].score.ToString(),
            TextStyle2);


        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 1.3f, Screen.width / 2, Screen.height / 11), "", btnStyle))
        {
            //scores_m.setcurScore(0);
            SceneManager.LoadScene(0);
        }


    }


}
