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
            float lado = coll.GetContact(0).point.x >= coll.collider.bounds.center.x ? 1f : -1f;
            float inclinacao = Random.Range(1f, 2f);
            rb2d.linearVelocity = new Vector2(lado * inclinacao, 1f).normalized * 6f;
        }
        if(coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);
            GameManager.Score();
            coll.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver); // Adiciona ponto ao destruir bloco
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.simulated = true;
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
        transform.position = new Vector2(0, -3);
    }

    void FreezeBall(){
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
        rb2d.simulated = false;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    void Death(){
        ResetBall();
        
    }

}
