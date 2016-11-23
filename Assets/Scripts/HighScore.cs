using UnityEngine;
using System.Collections;

public struct HighScore
{
    public string userName;
    public int score;

    public HighScore(string _username, int _score)
    {
        userName = _username;
        score = _score;
    }
}
