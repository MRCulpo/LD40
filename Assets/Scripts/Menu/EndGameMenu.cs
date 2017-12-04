using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        //SceneManager.LoadScene();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}