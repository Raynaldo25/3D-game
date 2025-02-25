using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    //public playerMovement myPlayer;
    private int score;

    public TextMeshProUGUI highScoreDisplay;
    public TextMeshProUGUI scoreDisplay;

    const string DIR_DATA = "/Data/";
    const string FILE_HIGH_SCORE = "highScore.txt";
    string PATH_HIGH_SCORE;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            if(score > HighScore)
            {
                HighScore = score;
            }
        }
    }

    int highScore;
    public int HighScore
    {
        get { return highScore; }
        set 
        {
            highScore = value; 
            Directory.CreateDirectory(Application.dataPath + DIR_DATA);
            File.WriteAllText(PATH_HIGH_SCORE, "" + HighScore);
        }
        
    }

    public float endTime = 15.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE;
        //highScoreDisplay.enabled = false;

        if (File.Exists(PATH_HIGH_SCORE))
        {
            HighScore = Int32.Parse(File.ReadAllText(PATH_HIGH_SCORE));
        }
    }

    // Update is called once per frame
    void Update()
    {
       // myPlayer = FindObjectOfType<playerMovement>();
        scoreDisplay.text = "Score: " + Score;
        highScoreDisplay.text = "High Score: " + HighScore;

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            endTime -= Time.deltaTime;
        }
        if (endTime <= 0.0f && SceneManager.GetActiveScene().name == "SampleScene")
        {
           // endTime = 10;
            //highScoreDisplay.enabled = true;
            SceneManager.LoadScene("won");
        }
        //score = myPlayer.score;

    }

    
}
