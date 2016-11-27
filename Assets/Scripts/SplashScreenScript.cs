using UnityEngine;
using System.Collections;

public class SplashScreenScript : MonoBehaviour {

    //public GUIStyle TextStyle;
    //public SpriteRenderer white;
    // Use this for initialization
    void Start () {
        StartCoroutine(Splash());
    }
	
	// Update is called once per frame
	void Update () {

        //TextStyle.fontSize = (int)(170.0f * (float)(Screen.width) / 1920.0f); //scale size font

    }

    IEnumerator Splash()
    {
        
        yield return new WaitForSeconds(2);
        //fadeIn();
        Application.LoadLevel(1);
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width / 8f, Screen.height / 7.6f, Screen.width / 6, Screen.width / 6), "Presented By:", TextStyle);

    }

    //public void fadeIn()
    //{
    //    StartCoroutine(fadeInTxt());

    //}


    //private IEnumerator fadeInTxt()
    //{
    //    float duration = 2f;
    //    float currentTime = 0f;

    //    float oldAlpha = 0.0f;
    //    float finalAlpha = 1.0f;

    //    while (currentTime < duration)
    //    {
    //        float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
    //        white.color = new Color(white.color.r, white.color.g, white.color.b, alpha);
    //        //tutRighttxt.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
    //        currentTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    yield break;
    //}


}
