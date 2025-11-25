using UnityEngine;

public class Quadro : MonoBehaviour
{
    public bool Caiu = false;

    public float duracao = 5f;

    private void OnMouseDown()
    {
        if (!Caiu)
        {
            StartCoroutine(CairSuavemente());
        }
    }

    private System.Collections.IEnumerator CairSuavemente()
    {
        Caiu = true;

        Quaternion rotInicial = transform.rotation;
        Quaternion rotFinal = Quaternion.Euler(0, 0, -30);

        float tempo = 0;

        while (tempo < duracao)
        {
            transform.rotation = Quaternion.Lerp(rotInicial, rotFinal, tempo / duracao);
            tempo += Time.deltaTime;
            yield return null;
        }
        transform.rotation = rotFinal;
    }
}
