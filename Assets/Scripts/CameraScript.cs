using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public bool Shaking;
    private float ShakeDecay;
    public float ShakeIntensity;
    private Vector3 OriginalPos;
    Vector3 startPos;
    public float time;

    bool hit = false;

    void Start()
    {
        Shaking = false;
        hit = false;
        startPos = new Vector3(0, 0, 0f);
    }

    void Update()
    {
        if (hit)
        {
            DoShake();

            time += Time.deltaTime;
        }
        if (ShakeIntensity > 0 && time <= 0.2)
        {
            transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
            ShakeIntensity -= ShakeDecay;
        }
    }

    public void setHit(bool inHit)
    {
        hit = inHit;
    }

    public void DoShake()
    {
        OriginalPos = transform.position;


        ShakeIntensity = 0.045f;
        ShakeDecay = .01f;
        Shaking = true;
    }
}