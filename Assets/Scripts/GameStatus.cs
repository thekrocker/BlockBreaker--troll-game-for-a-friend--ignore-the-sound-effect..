using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{       //parameters
    [Range(0.1f, 3f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlockDest = 31;
    [SerializeField] int scorePerBlockTouch = 10;

    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
                     bool isClickedAgain = false;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);  // Eğer birden fazla Gameobject varsa, yok ol. Yok ise Bir sonraki yükleyişte yok olma. 
        }

        else
        {
                DontDestroyOnLoad(gameObject);
            }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void AddtoScore()
    {
        currentScore += scorePerBlockDest; // currentScore = currentScore + scorePerBlock aynısı
        scoreText.text = currentScore.ToString();


    }

    public void ResetGame()
    {

        Destroy(gameObject);
    }

    public void AddToScoreOnTouch()
    {

        currentScore += scorePerBlockTouch;
        scoreText.text = currentScore.ToString();

    }

    public bool IsAutoPlayEnabled()
    {

        return isAutoPlayEnabled;
    }

    public void AutoPlayButton()
    {

        isAutoPlayEnabled = !isAutoPlayEnabled;  // Butona her basıldığında bool değeri değişir. 

     
    }


}
