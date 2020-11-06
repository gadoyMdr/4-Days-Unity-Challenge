using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class MainMenuManager : MonoBehaviour
{
    private GameManager gameManager;
    private CanvasManager canvasManager;
    public static bool isInMainMenu;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        canvasManager = GetComponent<CanvasManager>();
    }

    public void Start()
    {
        

        if (ReloadGameData.showMainMenu)
        {
            isInMainMenu = true;
            canvasManager.ToggleCanvases(new List<CanvasType> { CanvasType.MainMenu }, true);
        }

        else
        {
            isInMainMenu = false;
            canvasManager.ToggleCanvases(new List<CanvasType> { CanvasType.InGame }, true);
        }
            
            
    }

    public void Play()
    {
        gameManager.RestartGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
