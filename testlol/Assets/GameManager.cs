using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Text forceText, chargeText, pauseText;
    public GameObject forceUI, chargeUI, pauseUI;
    public GameObject paddle;
	// Use this for initialization
	void Start ()
    {
	    if (forceUI == null)
           forceUI = GameObject.Find("forceText");
        forceText = forceUI.GetComponent<Text>();
        if (chargeUI == null)
            chargeUI = GameObject.Find("chargeText");
        chargeText = chargeUI.GetComponent<Text>();
        if (pauseUI == null)
            pauseUI = GameObject.Find("pauseText");
        pauseText = pauseUI.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        forceText.text = "Force\n" + paddle.GetComponent<PaddleBehavior>().force + "";
        chargeText.text = "Charges\n" + paddle.GetComponent<PaddleBehavior>().charges + "";
        pauseText.text = "Pauses\n" + paddle.GetComponent<PaddleBehavior>().pauses + "";
    }
}
