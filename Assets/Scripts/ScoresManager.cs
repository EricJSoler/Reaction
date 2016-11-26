using UnityEngine;
using System.Collections;

public class ScoresManager : MonoBehaviour {
    //This class manages scores that will be available 
    //from one scene to another. Also thinking about 
    //putting leaderboard logic in hear as well.

    public static ScoresManager instance;

    const string privateCode = "HooqDaFhBUOESbiRRppCbQ2WWrdPcglEqb9N2R1XughA";
    const string publicCode = "583520dc8af6030dbcf810a2";
    const string webURL = "http://dreamlo.com/lb/";

    public int curScore;
    public string userName;

    public HighScore[] highScoresList;
    bool arrayReady = false;


    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        
    }


	// Use this for initialization
	void Start () {

    

    }
	
	// Update is called once per frame
	void Update () {
       // PlayerPrefs.DeleteAll();

	}

    public int getcurScore()
    {
        return curScore;
    }

    public void setcurScore(int inScore)
    {
        curScore = inScore;
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
    
    public void setHighScore(int inHigh)
    {
        PlayerPrefs.SetInt("HighScore", inHigh);
        
    }

    public void setNewUserName(string inName)
    {
        PlayerPrefs.SetString("Username", inName);
        userName = PlayerPrefs.GetString("Username");
    }
    public string getUsername()
    {
        return PlayerPrefs.GetString("Username");
    }

    public void AddNewLeadScore(string user, int score)
    {
        StartCoroutine(UploadNewHighScore(user, score));
    }


    IEnumerator UploadNewHighScore(string user, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(user) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            DownloadHighScores();
            Debug.Log("upload Successful");
        }
        else
        {
            Debug.Log("Error uploading " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownLoadHighScoresFromDatabase");
    }



    IEnumerator DownLoadHighScoresFromDatabase()
    {
        arrayReady = false;
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.text);
            FormatHighscores(www.text);
        }
        else
        {
            Debug.Log("Error Downloading " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new HighScore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoresList[i] = new HighScore(username, score);
            //Debug.Log(highScoresList[i].userName + ": " + highScoresList[i].score);
        }
        arrayReady = true;
       
    }

    public HighScore[] getHighScoreList()
    {
        return highScoresList;
    }

    public bool arReady()
    {
        return arrayReady;
    }
    //public struct HighScore
    //{
    //    public string userName;
    //    public int score;

    //    public HighScore(string _username, int _score)
    //    {
    //        userName = _username;
    //        score = _score;
    //    }
    //}


}
