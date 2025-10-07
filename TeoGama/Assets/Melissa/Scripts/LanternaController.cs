using UnityEngine;

public class LanternController : MonoBehaviour

{

    [Header("Configurações da Lanterna")]

    public Transform lanternTransform; // A mão segurando a lanterna

    public Transform lightTransform;   // Luz que sai da ponta da lanterna

    public float rotationSpeed = 10f;  // Velocidade de rotação suave

    [Header("Oscilação Natural")]

    public float swayAmount = 5f;      // Máximo de oscilação em graus

    public float swaySpeed = 2f;       // Velocidade do balanço

    [Header("Limite de Rotação")]

    public float minAngle = 22f;       // Ângulo mínimo permitido

    public float maxAngle = 37f;       // Ângulo máximo permitido

    void Update()

    {

        // Pega posição do mouse no mundo

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0f;

        // Calcula direção do mouse em relação à mão

        Vector3 direction = mousePos - lanternTransform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Adiciona leve oscilação

        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;

        // Limita o ângulo para que a mão não gire além do desenho

        float limitedAngle = Mathf.Clamp(angle + sway, minAngle, maxAngle);

        // Aplica rotação suave na mão

        Quaternion targetRotation = Quaternion.Euler(0, 0, limitedAngle);

        lanternTransform.rotation = Quaternion.Lerp(lanternTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Faz a luz seguir a rotação da ponta da lanterna

        if (lightTransform != null)

        {

            lightTransform.rotation = lanternTransform.rotation;

        }

    }

}
