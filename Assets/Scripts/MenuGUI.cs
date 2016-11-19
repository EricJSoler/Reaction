using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {


    string stringToEdit = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        stringToEdit = GUI.TextField(new Rect(Screen.width / 22f, Screen.height / 1.3f, Screen.width, Screen.height / 20), stringToEdit, 25);
    }
}
