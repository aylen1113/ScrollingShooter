using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public static GameScore inst;

    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;

    
    }


    private void Awake()
    {
        inst = this;
    }


}