using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public delegate void NoEnergy();
    public static event NoEnergy noEnergyEvent;

    [SerializeField] Slider energySlider;
    [SerializeField] private float energyRegeneration;
    [SerializeField] private float maxEnergy;
    public float currentEnergy = 0f;

    private void Start()
    {
        energySlider.maxValue = maxEnergy;
    }

    private void FixedUpdate()
    {
        RegenerateEnergy();
    }

    public bool UseEnergy(float amount, bool force = false)
    {
        if(currentEnergy - amount > 0 || force)
        {
            currentEnergy -= amount;
            if (currentEnergy < 0) currentEnergy = 0;
            return true;
        }
        else
        {
            noEnergyEvent?.Invoke();
            return false;
        }

    }

    void RegenerateEnergy()
    {
        currentEnergy += energyRegeneration;
        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        energySlider.value = currentEnergy;
    }
}
