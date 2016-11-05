using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour
{

    public Texture btnTexture;
    public GUIStyle TextStyle;
    public GUIStyle TextStyle2;
    public GUIStyle btnStyle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        TextStyle.fontSize = (int)(160.0f * (float)(Screen.width) / 1920.0f); //scale size font
        TextStyle2.fontSize = (int)(80.0f * (float)(Screen.width) / 1920.0f); //scale size font

    }


    void OnGUI()
    {


        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 5f, Screen.width / 6, Screen.width / 6), "Score: ", TextStyle);
        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 4f, Screen.width / 6, Screen.width / 6), "Best: ", TextStyle);
        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 3f, Screen.width / 6, Screen.width / 6), "World Best: ", TextStyle);
        GUI.Label(new Rect(Screen.width / 4.2f, Screen.height / 1.3f, Screen.width / 6, Screen.width / 6), "Leaderboards: ", TextStyle2);

        //GUI.Label(new Rect(10, 10, 100, 40), "GameOver");
        if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 11), "", btnStyle))
        {
            SceneManager.LoadScene(0);
        }



    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);

    }

}