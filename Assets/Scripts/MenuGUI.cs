using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGUI : MonoBehaviour {

    public GUIStyle TextStyle;
    public GUIStyle btnStyle2;

    public GameObject canvas;
    public string userName = "";


    public static GameObject saveScore;


    public InputField input;
    

    // Use this for initialization
    void Start () {

        saveScore = GameObject.Find("ScoreSave");
        //gt = GetComponent<GUIText>();
        //canvas = GameObject.Find("Canvas");
        //input = canvas.GetComponent<InputField>();

        if (saveScore.GetComponent<ScoresManager>().getUsername() != null)
        {

            input.text = saveScore.GetComponent<ScoresManager>().getUsername();
        }
    }
	
	// Update is called once per frame
	void Update () {
        TextStyle.fontSize = (int)(270.0f * (float)(Screen.width) / 1920.0f); //scale size font
        //userName = input.text;

        //userName = input.text;
        //Debug.Log("name " + userName.ToString());
    }

    void OnGUI()
    {

        //Title
        GUI.Label(new Rect(Screen.width / 4.5f, Screen.height / 8.5f, Screen.width / 6, Screen.width / 6), "Reaction", TextStyle);

        if (GUI.Button(new Rect(Screen.width / 3.5f, Screen.height / 1.4f, Screen.width / 2.3f, Screen.height / 11), "", btnStyle2))
        {

            
            
            userName = input.text;
            saveScore.GetComponent<ScoresManager>().setNewUserName(userName);
            

            Application.LoadLevel(1);
        }

        
    }


    //public string nameCheck(string name)
    //{
        
        

        
    //}


}
