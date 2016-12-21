using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public int force, charges, pauses;
    public GameObject forceOrigin, gameManager;
    GameManager gm;
    public float rotSpeed = 10f, gravity = .03f;
    bool paused = false;
    Vector2 savedVelocity;
    float savedAngularVelocity;
	// Use this for initialization
	void Start () {
        
        GetComponent<Rigidbody2D>().gravityScale = 0;
        gm = (GameManager) FindObjectOfType(typeof(GameManager));
        //gm = gameManager.GetComponent<GameManager>();

        gm.ChargeUpdate(charges);
        gm.PauseUpdate(pauses);
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
            gm.ForceUpdate(force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (force < 9999)
                force++;
            else
                force = 9999;
            gm.ForceUpdate(force);
        }

        transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X")) * rotSpeed);
        if (charges > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (paused)
                {
                    UnPause();
                } 
                Time.timeScale = 1;
                GetComponent<Rigidbody2D>().gravityScale = gravity;
                GetComponent<Rigidbody2D>().AddForce(transform.up * force);
                charges--;
                gm.ChargeUpdate(charges);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused)
            {
                UnPause();

               
            }
            else
            {
                if (pauses > 0)
                {
                    Time.timeScale = 0;
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    paused = true;
                    savedVelocity = GetComponent<Rigidbody2D>().velocity;
                    savedAngularVelocity = GetComponent<Rigidbody2D>().angularVelocity;
                    GetComponent<Rigidbody2D>().isKinematic = true;
                    pauses--;
                    gm.PauseUpdate(pauses);
                }
            }
        }
    }
    void UnPause()
    {
        Time.timeScale = 1;
        GetComponent<Rigidbody2D>().gravityScale = gravity;
        GetComponent<Rigidbody2D>().velocity = savedVelocity;
        GetComponent<Rigidbody2D>().angularVelocity = savedAngularVelocity;
        GetComponent<Rigidbody2D>().isKinematic = false;
        paused = false;
    }
}
