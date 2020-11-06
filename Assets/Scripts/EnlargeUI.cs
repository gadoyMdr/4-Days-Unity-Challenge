using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    [Range(1f, 2f)]
    private float bigScale = 1.3f;

    private Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(bigScale, bigScale, bigScale);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = baseScale;
    }
}
