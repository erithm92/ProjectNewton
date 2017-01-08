using UnityEngine;
using System.Collections;

public class PaddleBehavior : MonoBehaviour {
    public int force, charges, pauses;
    public GameObject forceOrigin, gameManage, ball, paddle, paddlePlacement;
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
        transform.position = ball.transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (force > 0)
                force -= 5;
            else
                force = 0;
            gm.ForceUpdate(force);
            if (paddle.transform.position != paddlePlacement.transform.position)
            {
                paddle.transform.position += (transform.up * force / 5000);
            }
            // transform.Rotate(new Vector3(0, 0, 1) * rotSpeed); //for mouse
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (force > 0)
                force-=10;
            else
                force = 0;
            gm.ForceUpdate(force);
            if(paddle.transform.position != paddlePlacement.transform.position)
            {
                paddle.transform.position += (transform.up * force/5000);
            }
           // transform.Rotate(new Vector3(0, 0, 1) * rotSpeed); //for mouse
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (force < 9999)
                force += 5;
            else
                force = 9999;
            gm.ForceUpdate(force);
            paddle.transform.position -= (transform.up * force / 5000);
            //transform.Rotate(new Vector3(0, 0, -1) * rotSpeed); // for mouse
        }
        if (Input.GetKey(KeyCode.D))
        {
             if (force < 9999)
                 force += 10;
             else
                 force = 9999;
             gm.ForceUpdate(force);
             paddle.transform.position -=(transform.up * force/5000);
            //transform.Rotate(new Vector3(0, 0, -1) * rotSpeed); // for mouse
        }
        /*if (Input.GetAxis("Mouse X") < 0 ) //for mouse
        {
            if (force > 0)
                force -= 10;
            else
                force = 0;
            gm.ForceUpdate(force);
            if (paddle.transform.position != paddlePlacement.transform.position)
            {
                paddle.transform.position += (transform.up * force / 10000);
            }
        }
        if(Input.GetAxis("Mouse X") > 0)
        {
            if (force < 9999)
                force += 10;
            else
                force = 9999;
            gm.ForceUpdate(force);
            paddle.transform.position -= (transform.up * force / 10000);
        }*/
        //original 
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
                ball.GetComponent<Rigidbody>().AddForce(transform.up * force);
                charges--;
                gm.ChargeUpdate(charges);
                paddle.transform.position = paddlePlacement.transform.position;
                force = 0;
                gm.ForceUpdate(force);
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
        ball.GetComponent<Rigidbody>().velocity = savedVelocity;
        ball.GetComponent<Rigidbody>().angularVelocity = savedAngularVelocity;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        paused = false;
    }
    void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        savedVelocity = ball.GetComponent<Rigidbody>().velocity;
        savedAngularVelocity = ball.GetComponent<Rigidbody>().angularVelocity;
        ball.GetComponent<Rigidbody>().isKinematic = true;
    }
}
