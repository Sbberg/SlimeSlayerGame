using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBehavior : MonoBehaviour
{
    public Slider Slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    // Start is called before the first frame update
    public void SetHealth(float health, float mHealth)
    {
        Slider.gameObject.SetActive(health < mHealth);
        Slider.value = health;
        Slider.maxValue = mHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
}
