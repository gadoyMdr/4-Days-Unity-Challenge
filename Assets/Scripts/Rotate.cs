using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 6.0f * rotateSpeed * Time.deltaTime);
    }
}
