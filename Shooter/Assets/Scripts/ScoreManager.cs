using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int kills = 0;

    private int missed = 0;

    private int friendsKilled = 0;

    public GUIText killsText;
    public GUIText friendsText;
    public GUIText missedText;

    private string killsPrefix;
    private string friendsPrefix;
    private string missedPrefix;



	// Use this for initialization
	void Start () {
        killsPrefix = killsText.text;
        friendsPrefix = friendsText.text;
        missedPrefix = missedText.text;
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddKill()
    {
        kills++;
        UpdateUI();
    }
    public void AddMiss()
    {
        missed++;
        UpdateUI();
    }
    public void AddFriendKill()
    {
        friendsKilled++;
        UpdateUI();
    }

    void UpdateUI()
    {
        killsText.text = killsPrefix + kills.ToString();
        friendsText.text = friendsPrefix + friendsKilled.ToString();
        missedText.text = missedPrefix + missed.ToString();
    }
}
