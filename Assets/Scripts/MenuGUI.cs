using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGUI : MonoBehaviour {

    public GUIStyle TextStyle;
    public GUIStyle btnStyle2;

    public GameObject canvas;


    //public GUIStyle btnStyle;
    string stringToEdit = "";

	// Use this for initialization
	void Start () {

        //canvas = GameObject.GetComponent<Canvas>();


    }
	
	// Update is called once per frame
	void Update () {
        TextStyle.fontSize = (int)(270.0f * (float)(Screen.width) / 1920.0f); //scale size font
    }

    void OnGUI()
    {

        //Title
        GUI.Label(new Rect(Screen.width / 4.5f, Screen.height / 8.5f, Screen.width / 6, Screen.width / 6), "Reaction", TextStyle);


        
        if (GUI.Button(new Rect(Screen.width / 3.5f, Screen.height / 1.4f, Screen.width / 2.3f, Screen.height / 11), "", btnStyle2))
        {
             Application.LoadLevel(1);
        }


        //stringToEdit = GUI.TextField(new Rect(Screen.width / 15f, Screen.height / 1.3f, Screen.width /1.5f, Screen.height / 20), stringToEdit, 35);
    }
}
