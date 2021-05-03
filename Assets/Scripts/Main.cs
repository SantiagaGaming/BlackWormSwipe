
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{


    public void OpenScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Player._scoreFloat = 0;
        Player._scoreEnemy = 0;
        Player.ContinueGame();
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }


}
