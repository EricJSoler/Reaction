using UnityEngine;
using System.Collections;

public class CircleScript : MonoBehaviour {

    public float radius;

    Vector2 screenPosition;
    //public GameObject GameManager;
    GameManager manager;
    public GameObject particleExplosion;

    public SpriteRenderer dotRenderer;

    private Vector2 direction;
    private float speed = 2f;
    
    void Start () {
        manager = FindObjectOfType<GameManager>();
        dotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        radius = this.gameObject.GetComponent<CircleCollider2D>().radius * this.transform.lossyScale.x;
        direction = new Vector2();

        //Debug.Log(radius);

        //Debug.Log(this.gameObject.transform.lossyScale);


    }


    void Update ()
    {
        if(!manager.worldBound.ObjectInsideWorldBound(this.transform.position, this.radius))
        {
            manager.generateNewMove();
            manager.changeDotPosition();
        }

        this.transform.position += (Vector3)((this.direction).normalized * this.speed * Time.deltaTime);
       // Debug.Log(this.direction);


    }

    void OnMouseDown()
    {

        //Instantiate(particleExplosion, this.transform.position, Quaternion.identity);

        manager.blueMove(this.transform);
        
    }

    public void updatePosition(Vector2 newPosition)
    {
        this.transform.position = newPosition;
        this.ChangeDirection();
        this.fadeIn();
    }

    //deprecating this and replacing it with move to new position going to let the game manager handle choosing where the circles are placed
    //public void changePosition()
    //{

    //    ////place dot on a random and new position within the screen boundrys
    //    ////screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));

    //    //Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
    //    //Vector2 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    //    //Vector2 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    //    //float x = Mathf.Clamp(temp.x, bottomLeftCorner.x + 1.85f, topRightCorner.x - 1.85f);
    //    //float y = Mathf.Clamp(temp.y, bottomLeftCorner.y + 1.85f, topRightCorner.y - 1.85f);

    //    //this.transform.position = new Vector2(x, y);

    //    //fadeIn();

    //}

    public void ChangeDirection()
    {
        float x = Random.Range(0, 100); 
        float y = Random.Range(0, 100);

        if(transform.position.x > manager.worldBound.BottomRightCoordinate.x / 2)
        {
            x *= -1;//flip x component to go left
        }

        if(transform.position.y > manager.worldBound.TopRightCoordinate.y / 2) // go up
        {
            y *= -1;//flip y component to go down
        }

        this.direction = new Vector2(x, y);

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
