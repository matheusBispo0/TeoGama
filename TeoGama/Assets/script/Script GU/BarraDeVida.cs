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
        AtualizarCor();
    }

    public void AtualizarCor()
    {
        float porcentagem = slider.value / slider.maxValue;

        if (porcentagem > 0.6f)
        {
            fill.color = Color.green;
        }
        else if (porcentagem > 0.3f)
        {
            fill.color = Color.yellow;
        }
        else
        {
            fill.color = Color.red;
        }
    }
}