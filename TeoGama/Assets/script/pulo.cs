using UnityEngine;



public class pulo : MonoBehaviour

{

    // Define a velocidade do jogador. "public" permite que você a edite no editor do Unity.

    public float speed = 5f;



    // Componente Rigidbody2D do jogador.

    private Rigidbody2D rb;



    void Start()

    {

        // Pega o componente Rigidbody2D no início do jogo.

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // Lê a entrada horizontal do teclado (teclas 'A'/'D' ou setas).

        float horizontalInput = Input.GetAxis("Horizontal");



        // Cria um vetor de movimento.

        Vector2 movement = new Vector2(horizontalInput, 0);



        // Define a velocidade do Rigidbody2D.

        rb.velocity = movement * speed;

    }

}