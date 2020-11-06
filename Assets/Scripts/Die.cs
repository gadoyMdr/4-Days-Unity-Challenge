using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public delegate void DieEvent();
    public event DieEvent dieEvent;

    public void DieFunction()
    {
        dieEvent?.Invoke();
        Destroy(gameObject);
    }
}
