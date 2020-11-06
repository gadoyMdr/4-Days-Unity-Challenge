using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlanName
{
    FirstPlan,
    SecondPlan,
    FarPlan
}

[System.Serializable]
public class Plan
{
    public float speedMultiplier;
    public PlanName planName;

    public static Plan firsPlan { get => new Plan(1f, PlanName.FirstPlan); }
    public static Plan secondPlan { get => new Plan(0.5f, PlanName.SecondPlan); }
    public static Plan farPlan { get => new Plan(0.15f, PlanName.FarPlan); }

    private Plan(float speedMultiplier, PlanName planName)
    {
        this.speedMultiplier = speedMultiplier;
        this.planName = planName;
    }
}
