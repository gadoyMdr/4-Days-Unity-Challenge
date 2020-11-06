using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public delegate void StartGame();
    public static event StartGame startGame;

    public void RestartGame()
    {
        ReloadGameData.showMainMenu = false;
        startGame?.Invoke();
        SceneManager.LoadScene("SampleScene");
    }

    public void GoMainMenu()
    {
        ReloadGameData.showMainMenu = true;
        SceneManager.LoadScene("SampleScene");
    }
}

public static class ReloadGameData
{
    public static bool showMainMenu = true;
}
