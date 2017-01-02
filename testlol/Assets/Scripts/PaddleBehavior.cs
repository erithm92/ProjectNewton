using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public int force, charges, pauses;
    public GameObject forceOrigin, gameManager;
    GameManager gm;
    public float rotSpeed = 10f, gravity = .03f;
    bool paused = false;
    Vector3 savedVelocity;
    Vector3 savedAngularVelocity;
	// Use this for initialization
	void Start () {
        gm = (GameManager) FindObjectOfType(typeof(GameManager));
        gm.ChargeUpdate(charges);
        gm.PauseUpdate(pauses);
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (force > 0)
                force-=10;
            else
                force = 0;
            gm.ForceUpdate(force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (force < 9999)
                force += 10;
            else
                force = 9999;
            gm.ForceUpdate(force);
        }

        transform.Rotate(new Vector3(0, 0, - Input.GetAxis("Mouse X")) * rotSpeed);
        if (charges > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (paused)
                {
                    UnPause();
                } 
                Time.timeScale = 1;
                GetComponent<Rigidbody>().AddForce(transform.up * force);
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
                    Pause();
                    pauses--;
                    gm.PauseUpdate(pauses);
                }
            }
        }
    }
    void UnPause()
    {
        Time.timeScale = 1;
        GetComponent<Rigidbody>().velocity = savedVelocity;
        GetComponent<Rigidbody>().angularVelocity = savedAngularVelocity;
        GetComponent<Rigidbody>().isKinematic = false;
        paused = false;
    }
    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        savedVelocity = GetComponent<Rigidbody>().velocity;
        savedAngularVelocity = GetComponent<Rigidbody>().angularVelocity;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
