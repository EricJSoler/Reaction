using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MenuGUI : MonoBehaviour {

    public GUIStyle TextStyle;
    public GUIStyle btnStyle2;

    public GameObject canvas;
    public string userName = "";


    public static GameObject saveScore;
    float infinite_timer = 0;


    float display_Text_Timer = 0;
    int text_counter = 0;


    public InputField input;


    public GameObject inf_Drag;

    //public AudioClip impact;
    public AudioClip audio;
    AudioSource audioSource;
    bool playAudioOnce;

    public SpriteRenderer titleRender;
    public SpriteRenderer underlineRender;
    //public CanvasRenderer textBoxRender;
    //public CanvasRenderer textRender;
    public Canvas menuCanvas;
    CanvasGroup canvasGroup;

    public CanvasGroup menutext1;
    public CanvasGroup menutext2;

    // Use this for initialization
    void Start () {
        playAudioOnce = false;
        saveScore = GameObject.Find("ScoreSave");
        //gt = GetComponent<GUIText>();
        //canvas = GameObject.Find("Canvas");
        //input = canvas.GetComponent<InputField>();
        inf_Drag.SetActive(false);

        canvasGroup = menuCanvas.GetComponent<CanvasGroup>();

        StartCoroutine(fadeName());


        audioSource = GetComponent<AudioSource>();

        if (saveScore.GetComponent<ScoresManager>().getUsername() == "unknown")
        {
            input.text = "";
        }
        else
        {
            input.text = saveScore.GetComponent<ScoresManager>().getUsername();
        }
    }






    // Update is called once per frame
    void Update () {
        TextStyle.fontSize = (int)(270.0f * (float)(Screen.width) / 1920.0f); //scale size font
        //userName = input.text;
        display_Text_Timer += (int) Time.deltaTime;
        //userName = input.text;
        //Debug.Log("name " + userName.ToString());
        if (saveScore.GetComponent<ScoresManager>().getUsername() == "")
        {
            Debug.Log("nothing");
        }

        if((Input.touchCount > 1) && input.text == "infinite")
        {
            infinite_timer += Time.deltaTime;
            //Debug.Log(infinite_timer);
            if (infinite_timer > 10f)
            {
                inf_Drag.SetActive(true);
                if (!playAudioOnce)
                {
                    audioSource.PlayOneShot(audio);
                    playAudioOnce = true;
                }
                //audio.Play(44100);
            }
        }
        else
        {
            infinite_timer = 0;
            inf_Drag.SetActive(false);
        }

    }

    void OnGUI()
    {

        //Title
        //GUI.Label(new Rect(Screen.width / 4.5f, Screen.height / 6.6f, Screen.width / 6, Screen.width / 6), "Reaction", TextStyle);

        //if (GUI.Button(new Rect(Screen.width / 3.5f, Screen.height / 1.6f, Screen.width / 2.3f, Screen.height / 10.5f), "", btnStyle2))
        //{

     
        //    userName = input.text;
        //    saveScore.GetComponent<ScoresManager>().setNewUserName(userName);

        //    fadeOut();
        //    //Application.LoadLevel(2);
        //}

        
    }

    public void onPlayClick()
    {
        userName = input.text;
        saveScore.GetComponent<ScoresManager>().setNewUserName(userName);
        fadeOut();
        
    }

    public void fadeOut()
    {
        StartCoroutine(fadeOutTxt());
        
    }


    private IEnumerator fadeOutTxt()
    {
        float duration = .4f;
        float currentTime = 0f;

        float oldAlpha = 1.0f;
        float finalAlpha = 0.0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            //blurRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tapRenderer.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            titleRender.color = new Color(titleRender.color.r, titleRender.color.g, titleRender.color.b, alpha);

            //textBoxRender.SetMaterial().color = new Color(textBoxRender.GetColor().r, textBoxRender.GetColor().g, textBoxRender.GetColor().b, alpha);
            canvasGroup.alpha = alpha;

            underlineRender.color = new Color(underlineRender.color.r, underlineRender.color.g, underlineRender.color.b, alpha);

            //tutLighttxt.color = new Color(blurRenderer.color.r, blurRenderer.color.g, blurRenderer.color.b, alpha);
            //tutRighttxt.color = new Color(tutRenderer.color.r, tutRenderer.color.g, tutRenderer.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        titleRender.GetComponent<Renderer>().enabled = false;
        underlineRender.GetComponent<Renderer>().enabled = false;
        canvasGroup.interactable = false;

        SceneManager.LoadScene(2);
        //blurRenderer.GetComponent<Renderer>().enabled = false;
        //tutLighttxt.GetComponent<Renderer>().enabled = false;
        //tutRighttxt.GetComponent<Renderer>().enabled = false;
        yield break;
    }



    private IEnumerator fadeName()
    {
        menutext2.alpha = 0;
        while (true)
        {

            
            yield return new WaitForSeconds(4);
            text_counter++;
            StartCoroutine(fadeDisplay());
            //Debug.Log("5 sec" + " " + text_counter + "");
            
            
        }
    }

    private IEnumerator fadeDisplay()
    {
      

            float duration = .7f;
            float currentTime = 0f;

            float oldAlpha = 1.0f;
            float finalAlpha = 0.0f;

            while (currentTime < duration)
            {
                float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
                
                float alpha2 = Mathf.Lerp(finalAlpha, oldAlpha, currentTime / duration);

            if (text_counter % 2 == 0)
            {
                menutext1.alpha = alpha2;
                menutext2.alpha = alpha;
            }
            else
            {
                menutext1.alpha = alpha;
                menutext2.alpha = alpha2;
            }


                currentTime += Time.deltaTime;
                yield return null;
            }
            
            //yield break;

        //}
        //else
        //{

        //    float duration = .4f;
        //    float currentTime = 0f;

        //    float oldAlpha = 1.0f;
        //    float finalAlpha = 0.0f;

        //    while (currentTime < duration)
        //    {
        //        float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);

        //        float alpha2 = Mathf.Lerp(finalAlpha, oldAlpha, currentTime / duration);

        //        menutext1.alpha = alpha2;
        //        menutext2.alpha = alpha;

        //        currentTime += Time.deltaTime;
        //        yield return null;
        //    }

            

        //}
        yield break;
    }




}
