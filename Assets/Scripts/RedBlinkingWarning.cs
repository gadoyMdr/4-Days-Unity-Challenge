using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RedBlinkingWarning : MonoBehaviour
{
    
    [SerializeField]
    private float blinkLength = 0.5f;

    [SerializeField]
    private int blinkCounts = 2;

    private Image _image;
    private Color baseColor;
    private bool currentlyBlinking = false;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        baseColor = _image.color;
    }

    public void OnEnable()
    {
        Energy.noEnergyEvent += Blink;
    }

    public void OnDisable()
    {
        Energy.noEnergyEvent -= Blink;
    }

    public void Blink()
    {
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        if (!currentlyBlinking)
        {
            for (int i = 0; i < blinkCounts; i++)
            {
                currentlyBlinking = true;
                StartCoroutine(OneBlinkCoroutine());
                yield return new WaitForSeconds(blinkLength);
            }
            currentlyBlinking = false;
        }
    }

    IEnumerator OneBlinkCoroutine()
    {
        _image.color = Color.red;
        yield return new WaitForSeconds(blinkLength);
        _image.color = baseColor;
    }
    
}
