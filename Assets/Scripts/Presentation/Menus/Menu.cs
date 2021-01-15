using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject RecordsMenu;
    public GameObject SettingsMenu;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowRecords()
    {
        RecordsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Settings()
    {
        SettingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
