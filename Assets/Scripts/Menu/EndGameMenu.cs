using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneConfig.MyScene);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}