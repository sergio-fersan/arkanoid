using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa o objeto bola
        Invoke("GoBall", 2);                    // Chama a função GoBall após 2 segundos
    }

    void Update()
    {
        
    }

    // inicializa a bola randomicamente para esquerda ou direita, para cima
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, 15));
        } else {
            rb2d.AddForce(new Vector2(-20, 15));
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel = rb2d.linearVelocity;

            // Dá uma influência da velocidade da nave
            vel.y += coll.collider.attachedRigidbody.linearVelocity.y * 0.3f;

            // Mantém uma velocidade mínima
            float velocidade = 6f;
            vel = vel.normalized * velocidade;

            rb2d.linearVelocity = vel;
        }
        if(coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);
            GameManager.Score();
            coll.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver); // Adiciona ponto ao destruir bloco
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.linearVelocity = Vector2.zero;
        transform.position = new Vector2(0, -3);
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

}
