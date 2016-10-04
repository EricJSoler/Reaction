using UnityEngine;
using System.Collections;

public class ParticleSy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        StartCoroutine(Autodestroy());
    }

    IEnumerator Autodestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
