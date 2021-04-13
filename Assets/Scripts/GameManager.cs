using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textLife = null;
    [SerializeField]
    private GameObject enemyCroissant = null;

    private int score = 0;
    private int life = 3;

    void Start()
    {
        StartCoroutine(SpawnCroissant());
    }

    public void UpdateUI()
    {
        textScore.text = string.Format("SCORE\n{0}", score);
        textLife.text = string.Format("LIFE\n{0}", life);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        UpdateUI();
    }

    public int GetLife()
    {
        return life;
    }

    public void Dead()
    {
        life--;
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }

    private IEnumerator SpawnCroissant()
    {
        float randomX = 0f;
        float randomDelay = 0f;

        while (true)
        {
            randomX = Random.Range(-7f, 7f);
            randomDelay = Random.Range(1f, 5f);
            for(int i = 0; i < 5; i++)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }            
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
