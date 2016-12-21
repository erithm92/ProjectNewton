using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {
    public GameObject winUI;
    public GameObject[] wronganswers, rightanswers;
    public int rightSelected;
    public bool wrong = false;
    public int rightanswercount;

    // Use this for initialization
    void Start()
    {
        if(winUI)
         winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }
    public void WinScreen(float lvlscore)
    {
        winUI.SetActive(true);
        winUI.GetComponent<Text>().text += "\n" + lvlscore;
    }
    public void SubmitAnswers()
    {
        if(!wrong)
        {
            float rightBonus = rightanswercount / rightSelected;
            if (rightBonus != 1)
            {

            }
        }
    }

}
