using UnityEngine;
using System.Collections;

public class CircleScript : MonoBehaviour {

    
    Vector2 screenPosition;
    //public GameObject GameManager;
    GameManager manager;
    public GameObject particleExplosion;

    public SpriteRenderer dotRenderer;
    
    
    void Start () {
        manager = FindObjectOfType<GameManager>();
        dotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
	
	
	void Update ()
    {

	}

    void OnMouseDown()
    {

        //Instantiate(particleExplosion, this.transform.position, Quaternion.identity);

        manager.blueMove(this.transform);
        
    }

    public void updatePosition(Vector2 newPosition)
    {
        this.transform.position = newPosition;
        this.fadeIn();
    }

    //deprecating this and replacing it with move to new position going to let the game manager handle choosing where the circles are placed
    public void changePosition()
    {

        //place dot on a random and new position within the screen boundrys
        //screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));

        Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
        Vector2 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        float x = Mathf.Clamp(temp.x, bottomLeftCorner.x + 1.85f, topRightCorner.x - 1.85f);
        float y = Mathf.Clamp(temp.y, bottomLeftCorner.y + 1.85f, topRightCorner.y - 1.85f);

        this.transform.position = new Vector2(x, y);

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
