using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{
    public GameObject ball;
    public float smooth = 1f;
	// Use this for initialization
	void Start ()
    {
	    if (ball == null)
        {
            ball = GameObject.Find("Ball");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y + 1, transform.position.z);
        /*if (Vector3.Distance(transform.position, ball.transform.position) > 1f)
        {
            transform.position = Vector3.Lerp(
           transform.position, new Vector3(ball.transform.position.x, ball.transform.position.y, transform.position.z),
           Time.deltaTime * smooth);
        }*/
    }
}
