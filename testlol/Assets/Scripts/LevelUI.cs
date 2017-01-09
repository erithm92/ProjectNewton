using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {
    public GameObject winUI, scoreUI, statsPanel;
    public GameObject[] wronganswers, rightanswers;
    public int rightSelected;
    public bool wrong = false;
    public bool isLevel;

    // Use this for initialization
    void Start()
    {
        if (winUI)
            winUI.SetActive(false);
        if (isLevel)
        {
           // Cursor.visible = false;
           // Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void WinScreen(float lvlscore)
    {
        winUI.SetActive(true);
        statsPanel.SetActive(false);
        scoreUI.GetComponent<Text>().text = "Level Score " + lvlscore;
      //  Cursor.visible = true;
       // Cursor.lockState = CursorLockMode.None;
    }
    public void CompleteLevel()
    {
        GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
        gm.LevelEnd();
    }
    public void Restart()
    {
        GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
        gm.Reload();
    }
    public void MainMenu()
    {
        GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
        gm.MainMenuLoad();
    }
    public void SubmitAnswers()
    {
        
        foreach (GameObject wrongAnswer in wronganswers)
        {
            if (wrongAnswer.GetComponent<Toggle>().isOn)
                wrong = true;
        }
        if(!wrong)
        {
            foreach (GameObject rightAnswer in rightanswers)
            {
                if (rightAnswer.GetComponent<Toggle>().isOn)
                    rightSelected++;
                
            }
     
            if (rightSelected == rightanswers.Length)
            {
                GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
                gm.LoadLevelAfterQuiz(2);
            }
            else if (rightSelected >=1)
            {
                GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
                gm.LoadLevelAfterQuiz(1);
            }
            else
            {
                GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
                gm.LoadLevelAfterQuiz(0);
            }
        }
        else
        {
            GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
            gm.LoadLevelAfterQuiz(0);
        }
    }

}
