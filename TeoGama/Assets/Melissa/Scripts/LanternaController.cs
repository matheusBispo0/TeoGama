using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
public class LanternaController : MonoBehaviour
{
    [Header("Referências")]
    public Transform lanternTransform;
    public Transform lightTransform;
    public Light2D spotLight; // Luz 2D real
    public TextMeshProUGUI contadorText;
    [Header("Movimento")]
    public float rotationSpeed = 10f;
    [Header("Oscilação Natural")]
    public float swayAmount = 3f;
    public float swaySpeed = 2f;
    [Header("Limite de Rotação")]
    public float minAngle = 22f;
    public float maxAngle = 40f;
    [Header("Configuração da Luz e Detecção")]
    public float range = 5f;
    public float coneAngle = 60f;
    public LayerMask enemyLayer;
    private bool luzLigada = true;
    private HashSet<GameObject> iluminados = new HashSet<GameObject>();
    private int inimigosContados = 0;
    void Update()
    {
        ControlarRotacao();
        ControlarLuz();
        if (luzLigada)
            DetectarInimigos();
    }
    void ControlarRotacao()
    {
        if (Camera.main == null) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector3 direction = mousePos - lanternTransform.position;
        float angleToMouse = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float centerAngle = (minAngle + maxAngle) / 2f;
        float halfRange = (maxAngle - minAngle) / 2f;
        float relativeAngle = Mathf.Clamp(angleToMouse - centerAngle, -halfRange, halfRange);
        float limitedAngle = centerAngle + relativeAngle;
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        limitedAngle += sway;
        Quaternion targetRotation = Quaternion.Euler(0, 0, limitedAngle);
        lanternTransform.rotation = Quaternion.Lerp(
            lanternTransform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
        if (lightTransform != null)
        {
            lightTransform.rotation = Quaternion.Lerp(
                lightTransform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
    void ControlarLuz()
    {
        if (Input.GetMouseButtonDown(1)) // clique direito liga/desliga
        {
            luzLigada = !luzLigada;
            if (spotLight != null)
                spotLight.enabled = luzLigada;
        }
    }
    void DetectarInimigos()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, enemyLayer);
        HashSet<GameObject> iluminadosAgora = new HashSet<GameObject>();
        foreach (Collider2D c in hits)
        {
            Vector2 dir = (c.transform.position - transform.position).normalized;
            Vector2 frente = transform.up;
            float angulo = Vector2.Angle(frente, dir);
            if (angulo <= coneAngle * 0.5f)
            {
                iluminadosAgora.Add(c.gameObject);
                var inimigo = c.GetComponent<InimigoLuz>();
                if (inimigo != null)
                {
                    if (!iluminados.Contains(c.gameObject))
                    {
                        inimigosContados++;
                        AtualizarTexto();
                    }
                    inimigo.HitByLight();
                }
            }
        }
        iluminados = iluminadosAgora;
    }
    void AtualizarTexto()
    {
        if (contadorText != null)
            contadorText.text = $"Inimigos iluminados: {inimigosContados}";
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
        Vector3 frente = transform.up * range;
        Quaternion esquerda = Quaternion.Euler(0, 0, -coneAngle / 2);
        Quaternion direita = Quaternion.Euler(0, 0, coneAngle / 2);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + esquerda * frente);
        Gizmos.DrawLine(transform.position, transform.position + direita * frente);
    }
}