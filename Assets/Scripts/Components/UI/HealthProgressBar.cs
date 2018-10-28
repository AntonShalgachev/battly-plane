using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthProgressBar : MonoBehaviour
{
    [SerializeField]
    private Health health;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.maxValue = health.GetMaxHealth();
        slider.value = health.GetHealth();
    }
}
