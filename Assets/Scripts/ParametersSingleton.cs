using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersSingleton
{
    public float speed = - 0.07f;

    private static ParametersSingleton Instance;
    public static ParametersSingleton instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new ParametersSingleton();
            }
            return Instance;
        }
    }

    
}
