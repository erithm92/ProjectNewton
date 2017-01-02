using UnityEngine;
using System.Collections;

public class Testapi : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameManager gm = GameManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartLevel()
    {
        GameManager a= (GameManager)FindObjectOfType(typeof(GameManager));
        a.LevelEnd();
    }
}
