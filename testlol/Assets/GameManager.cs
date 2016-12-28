﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using LoLSDK;

public class GameManager : MySingleton<GameManager>
{
    

    Text forceText, chargeText, pauseText, winText;
    int gamescore;
    public float lvlscore = 10;
    public int lvlCharges, lvlPauses, bonusCharges, bonusPauses;
    public GameObject forceUI, chargeUI, pauseUI, winUI;
    public GameObject paddle;

    // Use this for initialization
    void Awake()
    {
        //LOLSDK.Init("com.margolisdesign.projectnewton");
       
    }
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
    void OnLevelWasLoaded ()
    {
        if (forceUI == null)
            forceUI = GameObject.Find("forceText");
        if (forceUI != null)
            forceText = forceUI.GetComponent<Text>();
        if (chargeUI == null)
            chargeUI = GameObject.Find("chargeText");
        if (chargeUI != null)
            chargeText = chargeUI.GetComponent<Text>();
        if (pauseUI == null)
            pauseUI = GameObject.Find("pauseText");
        if (pauseUI != null)
            pauseText = pauseUI.GetComponent<Text>();
        if (paddle == null)
            paddle = GameObject.Find("Ball");
        if (paddle != null)
        {
            paddle.GetComponent<PaddleBehavior>().charges += bonusCharges;
            paddle.GetComponent<PaddleBehavior>().pauses += bonusPauses;
        }
        
    }
    public void Goal(float mod)
    {
        lvlscore = lvlscore * mod;
        LevelUI ui = (LevelUI)FindObjectOfType(typeof(LevelUI));
        ui.WinScreen(lvlscore);
        //LOLSDK.Instance.CompleteGame();
    }
    public void Reload()
    {
        SceneManager.LoadScene(1);
    }
    public void ChargeUpdate(int charges)
    {
        chargeText.text = "Charges\n" + charges + "";
    }
    public void PauseUpdate(int pauses)
    {
        pauseText.text = "Pauses\n" + pauses + "";
    }
    public void ForceUpdate(int force)
    {
        forceText.text = "Force\n" + force + "";
    }
    public void LoadLevelAfterQuiz(int bonus)
    {
        if (bonus == 2)
        {
            bonusCharges = 1;
            bonusPauses = 1;
        }
        else if (bonus == 1)
            bonusCharges = 1;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}
