using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0; // Pontuação do player 1

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball"); // Busca a referência da bola
    }

    void Update()
    {
        
    }

    public static void Score (string wallID) {
        if (wallID == "topWall")
        {
            PlayerScore++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore);

        // Botão RESTART na posição (0, 4)
        if (GUI.Button(new Rect(0, 4, 60, 26), "RESET"))
        {
            PlayerScore = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore == 3)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}