using UnityEngine;
using System.Collections;

public class ScoresManager : MonoBehaviour {

    public static ScoresManager instance;


    public int curScore;
    private int highScore;

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
        return highScore;
    }

    
    public void highScoreEval()
    {

    }


}
