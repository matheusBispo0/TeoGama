using UnityEngine;

public class LanternController : MonoBehaviour

{

    public Transform lantern; // objeto da lanterna

    public float maxAngle = 60f; // máximo para cima/baixo

    public float minAngle = -60f; // mínimo para cima/baixo

    void Update()

    {

        // Pega posição do mouse no mundo

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 0f;

        // Calcula direção da lanterna para o mouse

        Vector3 direction = mousePos - lantern.position;

        // Calcula o ângulo em graus

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Limita o ângulo

        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Aplica a rotação

        lantern.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

}
