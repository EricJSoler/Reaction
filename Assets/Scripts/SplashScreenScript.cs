using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour {

    //FadeScript fadeRef;

    void Start () {
        //fadeRef = GetComponent<FadeScript>();
        StartCoroutine(Splash());
    }

	void Update () {
    }

    IEnumerator Splash()
    {

        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene(1);
    }

    void OnGUI()
    {
    }

}
