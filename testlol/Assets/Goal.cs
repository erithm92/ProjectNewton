using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{
    GameObject gm;
	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
            gm.GetComponent<GameManager>().Goal();
    }
}
