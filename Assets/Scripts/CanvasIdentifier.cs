using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    Death,
    Pause,
    InGame
}

public class CanvasIdentifier : MonoBehaviour
{
    public CanvasType canvasType;
}
