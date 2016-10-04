using UnityEngine;
using System.Collections;

public class RedCircleScript : MonoBehaviour {

    Vector2 screenPosition;
    //public GameObject GameManager;
    GameManager manager;
   // public GameObject particleExplosion;

    public SpriteRenderer dotRenderer;
    

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        dotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {

    }

    void OnMouseDown()
    {
        
        //Instantiate(particleExplosion, this.transform.position, Quaternion.identity);
        manager.redMove(this.transform);
    }

    public void changePosition()
    {
        //place dot on a random and new position within the screen boundrys
        screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
        this.transform.position = screenPosition;

        fadeIn();

    }

    public void fadeIn()
    {
        StartCoroutine(fadeIntCR());
    }

    private IEnumerator fadeIntCR()
    {
        float duration = 0.5f;
        float currentTime = 0f;

        float oldAlpha = 0.0f;
        float finalAlpha = 1.0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(oldAlpha, finalAlpha, currentTime / duration);
            dotRenderer.color = new Color(dotRenderer.color.r, dotRenderer.color.g, dotRenderer.color.b, alpha);

            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }



}
