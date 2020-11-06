using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private List<CanvasIdentifier> canvas = new List<CanvasIdentifier>();

    private void Start()
    {
        StartSession();
    }

    public void ToggleCanvases(List<CanvasType> canvasTypesList, bool value)
    {
        ToggleAllCanvases(!value);

        foreach (CanvasType canvasType in canvasTypesList)
        {
            CanvasIdentifier current = canvas.First(x => x.canvasType.Equals(canvasType));
            if (current != null) current.gameObject.SetActive(value);

        }
    }

    public CanvasIdentifier GetCanvas(CanvasType canvasType) => canvas.First(x => x.canvasType.Equals(canvasType));

    void ToggleAllCanvases(bool value)
    {
        foreach (CanvasIdentifier canvasIdentifier in canvas) canvasIdentifier.gameObject.SetActive(value);
    }

    void StartSession()
    {
        if(ReloadGameData.showMainMenu) ToggleCanvases(new List<CanvasType> { CanvasType.MainMenu }, true);
    }
}
