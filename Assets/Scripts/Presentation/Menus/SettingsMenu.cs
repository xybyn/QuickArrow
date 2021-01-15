using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_InputField InputField;
    public GameObject Menu;
    public PlayerService PlayerService;
    private void OnEnable()
    {
        InputField.text = PlayerService.Player.Username;
    }
    public void SaveUsername()
    {
        var newUsername = InputField.text;
        if(!string.IsNullOrEmpty(newUsername))
        {
            PlayerService.UpdateUsername(newUsername);
        }
    }

    public void BackToMenu()
    {
        Menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
