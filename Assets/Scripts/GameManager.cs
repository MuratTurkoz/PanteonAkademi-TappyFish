using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lastScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject newImage;
    [SerializeField] Image[] CoinImages;
    [SerializeField] Image CoinImage;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnManger;
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject gameEnd;
    [SerializeField] AudioClip musicMain;
    public int score;
    int loadScore;
    AudioSource audioSource;
    public static bool gameOver;

    void Start()
    {
        
        gameOver = false;
        score = 0;
        audioSource = GetComponent<AudioSource>();

        //gameObject.GetComponent<DataManager>().SaveScore(0);
        //audioSource.PlayOneShot(musicMain);

    }

    void Update()
    {
        scoreText.text = score.ToString();  
    }
    private void GetScore()
    {
        loadScore = gameObject.GetComponent<DataManager>().LoadScore();
        if (loadScore < score)
        {
            newImage.SetActive(true);
            bestScoreText.text = score.ToString();
            gameObject.GetComponent<DataManager>().SaveScore(score);
        }
        else
        {
            bestScoreText.text = loadScore.ToString();
            newImage.SetActive(false);
        }
    }
    private void GetCoinImage()
    {
        if (score <= 10)
        {
            CoinImage.sprite = CoinImages[0].sprite;
        }
        else if (11 < score && score <= 40)
        {
            CoinImage.sprite = CoinImages[1].sprite;

        }
        else if (score >= 41)
        {
            CoinImage.sprite = CoinImages[2].sprite;
        }
    }

    public void LevelStart()
    {
        gameStart.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.SetActive(true);
        spawnManger.SetActive(true);
    }
    public void CrushObstacle()
    {
        GetScore();
        GetCoinImage();
        GameOver();
    }

   
    public void RetryLevel()
    {
        //timer = 0;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        Destroy(gameObject);

    }
    public void AddScore()
    {
        score++;
    }
    public void GameOver()
    {
        lastScoreText.text = scoreText.text;
        gameEnd.gameObject.SetActive(true);
        spawnManger.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameOver = true;
    }
  
}
