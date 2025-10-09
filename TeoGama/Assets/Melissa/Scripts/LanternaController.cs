using UnityEngine;
public class LanternaController : MonoBehaviour
{
    [Header("Referências")]
    public Transform lanternTransform; // A mão segurando a lanterna
    public Transform lightTransform;   // Luz (Spot Light ou Light2D)
    [Header("Configurações de Movimento")]
    public float rotationSpeed = 10f;  // Suavidade da rotação
    [Header("Oscilação Natural da Mão")]
    public float swayAmount = 3f;      // Máximo de oscilação (em graus)
    public float swaySpeed = 2f;       // Velocidade da oscilação
    [Header("Limite de Rotação")]
    public float minAngle = 22f;       // Ângulo mínimo permitido
    public float maxAngle = 40f;       // Ângulo máximo permitido
    void Update()
    {
        if (Camera.main == null) return;
        // === POSIÇÃO DO MOUSE NO MUNDO ===
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        // === DIREÇÃO DO MOUSE EM RELAÇÃO À MÃO ===
        Vector3 direction = mousePos - lanternTransform.position;
        float angleToMouse = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // === MAPEAR MOVIMENTO DO MOUSE DENTRO DO INTERVALO ===
        // Isso mantém o mouse "seguido" mesmo com limite
        float centerAngle = (minAngle + maxAngle) / 2f;
        float halfRange = (maxAngle - minAngle) / 2f;
        // Calcula diferença entre o mouse e o centro, limita ao intervalo
        float relativeAngle = Mathf.Clamp(angleToMouse - centerAngle, -halfRange, halfRange);
        float limitedAngle = centerAngle + relativeAngle;
        // === OSCILAÇÃO NATURAL ===
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        limitedAngle += sway;
        // === ROTAÇÃO SUAVE (mesma para mão e luz) ===
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
}