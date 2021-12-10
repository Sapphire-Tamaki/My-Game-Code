using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI scoreText;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + points;
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        // Start counting score
        Invoke("AddScore", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore()
    {
        if (!player.gameOver)
        {
            points++;
            scoreText.text = "Score: " + points;
            Invoke("AddScore", 1);
        }
    }
    public void AddScore(int score)
    {
        if (!player.gameOver)
        {
            points += score;
        }
    }
}
