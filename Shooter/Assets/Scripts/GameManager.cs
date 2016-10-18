using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject gameOver;
    public GameObject youWin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Lose()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0;
        youWin.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
