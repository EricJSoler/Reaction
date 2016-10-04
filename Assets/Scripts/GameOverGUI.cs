using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnGUI()
    {

        //GUI.Label(new Rect(10, 10, 100, 40), "GameOver");


       
    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);

    }

}
