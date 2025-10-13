using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class InimigoLuz : MonoBehaviour

{

    private SpriteRenderer sr;

    private Color corOriginal;

    private bool sendoIluminado = false;

    private bool jaIluminado = false;

    private float fadeTimer = 0f;

    [Header("Configuração de Aparição/Desaparecimento")]

    public float tempoParaSumir = 1.5f; // tempo total pra sumir

    public float tempoParaAparecer = 0.3f; // tempo pra clarear ao ser iluminado

    public Color corIluminado = Color.white; // cor que ele fica quando a lanterna pega

    public bool reapareceDepois = false; // opcional: volta a ser escuro após sumir

    void Awake()

    {

        sr = GetComponent<SpriteRenderer>();

        corOriginal = sr.color;

        // começa totalmente escuro

        sr.color = new Color(corOriginal.r, corOriginal.g, corOriginal.b, 0f);

    }

    void Update()

    {

        if (sendoIluminado)

        {

            fadeTimer += Time.deltaTime;

            // Primeiro: clareia até branco no início

            if (fadeTimer < tempoParaAparecer)

            {

                float t = fadeTimer / tempoParaAparecer;

                Color c = Color.Lerp(new Color(0, 0, 0, 0), corIluminado, t);

                sr.color = c;

            }

            else

            {

                // Depois de aparecer, começa a desaparecer

                float t = (fadeTimer - tempoParaAparecer) / tempoParaSumir;

                Color c = Color.Lerp(corIluminado, new Color(0, 0, 0, 0), t);

                sr.color = c;

                if (t >= 1f)

                {

                    if (reapareceDepois)

                    {

                        Resetar();

                    }

                    else

                    {

                        gameObject.SetActive(false);

                    }

                    sendoIluminado = false;

                }

            }

        }

    }

    public void HitByLight()

    {

        if (!jaIluminado)

        {

            sendoIluminado = true;

            jaIluminado = true;

            fadeTimer = 0f;

        }

    }

    private void Resetar()

    {

        jaIluminado = false;

        sr.color = new Color(0, 0, 0, 0);

    }

}
