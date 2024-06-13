using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    public Text scoreText; 
    public Text winText;   

    private void Awake()
    {
        inst = this;
        winText.gameObject.SetActive(false); 
    }

 
    public void AddScore(int increment)
    {
        score += increment;
        scoreText.text = "SCORE: " + score;
        Debug.Log(scoreText);

        CheckWinCondition(); 
    }

    private void CheckWinCondition()
    {
        if (score >= 1000)
        {
            WinGame();
        }
    }

    
    private void WinGame()
    {
        winText.gameObject.SetActive(true); 
        winText.text = "VICTORY!";
        Debug.Log("Victory!");
        Time.timeScale = 0; 
    }
}
