using UnityEngine;
using System.Collections;

public class ScoresManager : MonoBehaviour {
    //This class manages scores that will be available 
    //from one scene to another. Also thinking about 
    //putting leaderboard logic in hear as well.

    public static ScoresManager instance;


    public int curScore;
    

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


}
