using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    private int score;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;
    

    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        spawnRate /= difficulty;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
       
    }
   public void GameOver()
   {
       isGameActive = false;
       gameOverText.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
