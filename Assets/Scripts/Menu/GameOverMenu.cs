using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI currentScore;
    [SerializeField]
    TextMeshProUGUI highScore;

    void OnEnable()
    {
        int score = 0;
        currentScore.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }
        else
        {
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    void OnDisable()
    {
        currentScore.text = "";
        highScore.text = "";
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}