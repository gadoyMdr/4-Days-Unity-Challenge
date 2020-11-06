using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    private CanvasManager canvasManager;

    private void Awake()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    private void Start()
    {
        InferAutoPlay();
    }

    void InferAutoPlay()
    {
        if (gameObject.TryGetComponent(out AutoPlay autoPlay)) autoPlay.enabled = 
                canvasManager.GetCanvas(CanvasType.MainMenu).gameObject.activeInHierarchy;
    }
}
