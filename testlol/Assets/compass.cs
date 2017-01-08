using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class compass : MonoBehaviour
{
    public GameObject ball,magText;
    Rigidbody ballrb;
	// Use this for initialization
	void Start ()
    {
        ballrb = ball.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
            Vector3 moveDirection = ballrb.velocity;
            if (moveDirection != Vector3.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                Quaternion targetRot = Quaternion.AngleAxis(-angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 300 * Time.deltaTime);
            }
        magText.GetComponent<Text>().text = Mathf.RoundToInt(ballrb.velocity.magnitude) + "m/s";
    }
}
