using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelProgressBar : MonoBehaviour
{
    [SerializeField]
    private FuelTank tank;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.maxValue = tank.MaxFuelLevel;
        slider.value = tank.FuelLevel;
    }
}
