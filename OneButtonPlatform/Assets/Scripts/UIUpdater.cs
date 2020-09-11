using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    public ScoreObject highScoreFloat;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = Mathf.Round(player.transform.position.y).ToString();
        highScore.text = Mathf.Round(highScoreFloat.@float).ToString();
    }
}
