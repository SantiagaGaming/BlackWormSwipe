using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] Text text;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
            PlayerPrefs.SetInt("Score", 0);
        text.text = PlayerPrefs.GetInt("Score").ToString();
    }
    public void OpenScene1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Player._scoreFloat = 0;
        Player._scoreEnemy = 0;
        Player._isAlive = true;
    }


}
