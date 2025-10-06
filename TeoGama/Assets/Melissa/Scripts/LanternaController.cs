using UnityEngine;
using UnityEngine.Rendering.Universal; // para Light2D
public class LanternaController : MonoBehaviour
{
    public Transform maoLanterna;       // sprite da m�o e lanterna
    public Light2D luzLanterna;         // sua luz Spot Light 2D
    public float offsetRotacao = -90f;  // ajuste se a rota��o ficar torta
    void Update()
    {
        // Pega posi��o do mouse no mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        // Dire��o entre player e mouse
        Vector3 direcao = mousePos - transform.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        // Rotaciona a lanterna e a m�o
        maoLanterna.rotation = Quaternion.Euler(0, 0, angulo + offsetRotacao);
        // Faz a luz olhar na mesma dire��o
        luzLanterna.transform.rotation = Quaternion.Euler(0, 0, angulo + offsetRotacao);
    }
}