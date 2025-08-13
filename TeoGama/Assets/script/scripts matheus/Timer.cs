using UnityEngine;

using UnityEngine.UI;

public class Cronometro : MonoBehaviour

{

    public Text textoCronometro; 

    public int minutosLimite = 2; //limite que o cronômetro vai ter 

    private int minutos = 0;

    private int segundos = 0;

    private float contador = 0f;

    private bool rodando = false;

    void Start()

    {

        //iniciar automaticamente

        Iniciar();

    }

    void Update()

    {

        if (!rodando) return;

        contador += Time.deltaTime;

        if (contador >= 1f)

        {

            contador = 0f;

            segundos++;

            if (segundos >= 60)

            {

                segundos = 0;

                minutos++;

            }

            if (minutos >= minutosLimite)

            {

                Parar();

                Debug.Log("Cronômetro atingiu " + minutosLimite + " minutos.");

            }

            else

            {

                Debug.Log($"Tempo decorrido: {minutos:D2}:{segundos:D2}");

            }

            AtualizarTexto();

        }

    }

    public void Iniciar()

    {

        rodando = true;

    }

    public void Parar()

    {

        rodando = false;

    }

    public void Resetar()

    {

        minutos = 0;

        segundos = 0;

        contador = 0f;

        AtualizarTexto();

    }

    private void AtualizarTexto()

    {

        if (textoCronometro != null)

        {

            textoCronometro.text = $"{minutos:D2}:{segundos:D2}";

        }

    }

}
