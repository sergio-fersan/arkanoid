using UnityEngine;

public class NaveControl : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;      // Move a nave para a esquerda
    public KeyCode moveRight = KeyCode.D;    // Move a nave para a direita
    public float speed = 6.0f;             // Define a velocidade da nave
    public float boundX = 2.5f;            // Define os limites em X
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a nave

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a nave
    }

    void Update()
    {
        var vel = rb2d.linearVelocity;                // Acessa a velocidade da nave
        if (Input.GetKey(moveRight)) {             // Velocidade da nave para ir para a esquerda
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft)) {      // Velocidade da nave para ir para a direita
            vel.x = -speed;                    
        }
        else {
            vel.x = 0;                          // Velociade para manter a nave parada
        }
        rb2d.linearVelocity = vel;                    // Atualizada a velocidade da nave

        var pos = transform.position;           // Acessa a Posição da nave
        if (pos.x > boundX) {                  
            pos.x = boundX;                     // Corrige a posicao da nave caso ele ultrapasse o limite direito
        }
        else if (pos.x < -boundX) {
            pos.x = -boundX;                    // Corrige a posicao da nave caso ele ultrapasse o limite esquerdo
        }
        transform.position = pos;               // Atualiza a posição da nave

    }

}
