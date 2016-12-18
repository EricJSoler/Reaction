using UnityEngine;
using System.Collections;

public class GreenCircleScript : MonoBehaviour
{

    public SpriteRenderer dotRenderer;
    public float radius;
    GameManager manager;
    Vector2 direction = new Vector2();

    private float speed = 1f;



    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }


    // Use this for initialization
    void Start () {
        dotRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        radius = this.gameObject.GetComponent<CircleCollider2D>().radius * this.transform.lossyScale.x;

    }
	
	// Update is called once per frame
	void Update () {

        if (!manager.worldBound.ObjectInsideWorldBound(this.transform.position, this.radius))
        {
            manager.generateNewMove();
            manager.changeDotPosition();
        }

        this.transform.position += (Vector3)((this.direction).normalized * this.speed * Time.deltaTime);


    }

    void OnMouseDown()
    {

        //Instantiate(particleExplosion, this.transform.position, Quaternion.identity);
        manager.greenMove(this.transform);
    }

    public void updatePosition(Vector2 newPosition)
    {
        this.transform.position = newPosition;
        this.ChangeDirection();
        this.fadeIn();
    }



    public void ChangeDirection()
    {
        float x = Random.Range(0, 100);
        float y = Random.Range(0, 100);



        if (this.transform.position.x > manager.worldBound.BottomRightCoordinate.x / 2)
        {
            x *= -1;//flip x component to go left
        }

        if (this.transform.position.y > manager.worldBound.TopRightCoordinate.y / 2) // go up
        {
            y *= -1;//flip y component to go down
        }

        if (manager == null)
            Debug.Log("Manager null");
        else if (manager.worldBound == null)
        {
            Debug.Log("worldbound null");
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
