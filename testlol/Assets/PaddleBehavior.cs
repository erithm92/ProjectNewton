using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public int force, charges, pauses;
    public GameObject parent, forceOrigin;
    public float rotSpeed = 10f, gravity = .03f;
    bool paused = false;
    Vector2 savedVelocity;
    float savedAngularVelocity;
	// Use this for initialization
	void Start () {
        parent = transform.parent.gameObject;
        parent.GetComponent<Rigidbody2D>().gravityScale = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (force > 0)
                force--;
            else
                force = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (force < 9999)
                force++;
            else
                force = 9999;
        }

        float mouseHor = Input.GetAxis("Mouse X");

        parent.transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * rotSpeed);
        if (charges > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (paused)
                {
                    Debug.Log("paused");

                    Time.timeScale = 1;
                    parent.GetComponent<Rigidbody2D>().gravityScale = gravity;
                    parent.GetComponent<Rigidbody2D>().velocity = savedVelocity;
                    parent.GetComponent<Rigidbody2D>().angularVelocity = savedAngularVelocity;
                    parent.GetComponent<Rigidbody2D>().isKinematic = false;
                    paused = false;
                } 
                Time.timeScale = 1;
                parent.GetComponent<Rigidbody2D>().gravityScale = gravity;
                parent.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
                charges--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                Debug.Log("paused");

                Time.timeScale = 1;
                parent.GetComponent<Rigidbody2D>().gravityScale = gravity;
                parent.GetComponent<Rigidbody2D>().velocity = savedVelocity;
                parent.GetComponent<Rigidbody2D>().angularVelocity = savedAngularVelocity;
                parent.GetComponent<Rigidbody2D>().isKinematic = false;
                paused = false;
            }
            else
            {
                if (pauses > 0)
                {
                    Time.timeScale = 0;
                    parent.GetComponent<Rigidbody2D>().gravityScale = 0;
                    paused = true;
                    savedVelocity = parent.GetComponent<Rigidbody2D>().velocity;
                    savedAngularVelocity = parent.GetComponent<Rigidbody2D>().angularVelocity;
                    parent.GetComponent<Rigidbody2D>().isKinematic = true;
                    pauses--;
                }
            }
        }
    }
}
