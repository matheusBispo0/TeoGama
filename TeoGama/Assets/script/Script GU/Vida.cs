using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Slider slider;
    public float health = 100f;
    public float VidaMax = 100f;

    void Start()
    {
        slider.maxValue = VidaMax;
        slider.value = health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount; 
        UpdateHealthBar(); 
    }

    public void Heal(float amount)
    {
        health += amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        health = Mathf.Clamp(health, 0, VidaMax); 
        slider.value = health;
    }

}