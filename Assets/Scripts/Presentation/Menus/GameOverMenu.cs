using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour, IGameStartSender
{
    public event Action OnGameStarted;

    public TMPro.TextMeshProUGUI Text;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void SetText(string text)
    {
        Text.text = text;
    }
}
