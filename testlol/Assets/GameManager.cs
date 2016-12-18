using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LoLSDK;

public class GameManager : MonoBehaviour {
    Text forceText, chargeText, pauseText, winText;
    public GameObject forceUI, chargeUI, pauseUI, winUI;
    public GameObject paddle;
	// Use this for initialization
	void Start ()
    {
        LOLSDK.Init("com.margolisdesign.projectnewton");
        if (forceUI == null)
           forceUI = GameObject.Find("forceText");
        forceText = forceUI.GetComponent<Text>();
        if (chargeUI == null)
            chargeUI = GameObject.Find("chargeText");
        chargeText = chargeUI.GetComponent<Text>();
        if (pauseUI == null)
            pauseUI = GameObject.Find("pauseText");
        pauseText = pauseUI.GetComponent<Text>();
        if (winUI == null)
            winUI = GameObject.Find("winText");
        winText = winUI.GetComponent<Text>();
        winUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        forceText.text = "Force\n" + paddle.GetComponent<PaddleBehavior>().force + "";
        chargeText.text = "Charges\n" + paddle.GetComponent<PaddleBehavior>().charges + "";
        pauseText.text = "Pauses\n" + paddle.GetComponent<PaddleBehavior>().pauses + "";
    }
    public void Goal()
    {
        winUI.SetActive(true);
        LOLSDK.Instance.CompleteGame();
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
