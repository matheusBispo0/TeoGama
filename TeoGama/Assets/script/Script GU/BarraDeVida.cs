using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxVida(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }


    public void SetVida(int vida)
    {
        slider.value = vida;
    }

}