using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameQL : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    private bool isGameWin = false;
    private bool isGameOver = false;
    void Start()
    {
        UpdateScoreText();
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addscore(int value)
    {
        if (!isGameOver && !isGameWin) { 
            score += value;
            UpdateScoreText();
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text =score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUI.SetActive(true);
    }
    public void ResetStartGame()
    {
        StartCoroutine(ResetGameRoutine());
    }
    public void goToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator ResetGameRoutine()
    {
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.20f);
        score = 0; 
        UpdateScoreText();
        isGameOver = false;
        gameOverUI.SetActive(false);
        
        SceneManager.LoadScene("LV_2");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
