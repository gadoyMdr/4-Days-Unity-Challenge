using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsPullOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform menu;

    private void Awake()
    {
        menu = GetComponent<RectTransform>();
    }

    private void Start()
    {
        PullIn();
    }

    public void ChangeMusicVolume(float value)
    {
        FindObjectOfType<AudioSource>().volume = value;
    }

    void PullOut()
    {
        if (!MainMenuManager.isInMainMenu) Time.timeScale = 0f;
        menu.anchoredPosition = new Vector2(0, 0);
    }

    void PullIn()
    {
        Time.timeScale = 1f;
        menu.anchoredPosition = new Vector2(0, 157);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PullIn();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PullOut();
    }
}
