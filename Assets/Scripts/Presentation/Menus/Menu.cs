using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject RecordsMenu;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowRecords()
    {
        RecordsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
