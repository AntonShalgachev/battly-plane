using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    [SerializeField]
    private float capacity;

    public float MaxFuelLevel
    {
        get { return capacity; }
    }
    public float FuelLevel { get; private set; }

    private void Awake()
    {
        FuelLevel = capacity;
    }

    public void Burn(float amount)
    {
        FuelLevel -= amount;
    }

    public bool IsEmpty()
    {
        return FuelLevel < 0.0f;
    }
}
