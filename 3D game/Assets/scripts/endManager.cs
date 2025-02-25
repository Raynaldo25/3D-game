using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class endManager : MonoBehaviour
{
    public gameManager GM;
    private int endScore;
    private int endHigh;

    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        endScore = GM.Score;
        endHigh = GM.HighScore;
        scoreDisplay.text = "Score: " + endScore;
        highScoreDisplay.text = "High Score: " + endHigh;
    }
}
