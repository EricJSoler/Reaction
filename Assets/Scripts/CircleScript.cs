using UnityEngine;
using System.Collections;

public class CircleScript : MonoBehaviour
{

    [SerializeField]
    public string color;


    public float radius;

    Vector2 screenPosition;

    GameManager manager;

    public SpriteRenderer dotRenderer;

    private Vector2 direction;
    [SerializeField]
    private float speed = 1;
    public float Speed
    {
        get { return speed; }

        set { speed = value; }
    }

    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        direction = new Vector2();
    }

    void Start()
    {

        dotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        radius = this.gameObject.GetComponent<CircleCollider2D>().radius * this.transform.lossyScale.x;
        
    }


    void Update()
    {
        if (!manager.worldBound.ObjectInsideWorldBound(this.transform.position, this.radius))
        {
            manager.EscapedScreen(this.color);
        }

        this.transform.position += (Vector3)((this.direction).normalized * this.speed * Time.deltaTime);
    }

    void OnMouseDown()
    {

        //Instantiate(particleExplosion, this.transform.position, Quaternion.identity);
        manager.DotClicked(this.color, this.transform);
        //manager.blueMove(this.transform);

    }

    public void updatePosition(Vector2 newPosition)
    {
        this.transform.position = newPosition;
        //this.ChangeDirectionToFarthestPath();
        this.fadeIn();
    }

    //deprecating this and replacing it with move to new position going to let the game manager handle choosing where the circles are placed
    //public void changePosition()
    //{

    //    //place dot on a random and new position within the screen boundrys
    //    //screenPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));

    //    Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
    //    Vector2 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    //    Vector2 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    //    float x = Mathf.Clamp(temp.x, bottomLeftCorner.x + 1.85f, topRightCorner.x - 1.85f);
    //    float y = Mathf.Clamp(temp.y, bottomLeftCorner.y + 1.85f, topRightCorner.y - 1.85f);

    //    this.transform.position = new Vector2(x, y);

    //    fadeIn();

    //}
    public void SetDirection(Vector2 dir)
    {
        this.direction = dir;
    }

    public void ChangeDirectionToFarthestPath() //poorlly named this sho
    {
        float x = Random.Range(0, 100);
        float y = Random.Range(0, 100);

        if (transform.position.x > manager.worldBound.BottomRightCoordinate.x / 2)
        {
            x *= -1;//flip x component to go left
        }

        if (transform.position.y > manager.worldBound.TopRightCoordinate.y / 2) // go up
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
