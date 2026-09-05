using UnityEngine;
using UnityEngine.SceneManagement;   

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0; // Pontuação do player 1
    public static int TotalScore = 0;
    public static int PlayerLives = 3;
    public static int FinalScore;
    public static bool PlayerWon;

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola
    bool gameOverScheduled;
    bool victoryScheduled;
    string nextScene;

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball"); // Busca a referência da bola
    }

    void Update()
    {
        
    }

    public static void Death(){
        PlayerLives--;
    }

    public static void Score () {
        PlayerScore++;
        TotalScore++;
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 80, 100, 100), "" + PlayerLives);
        
        // Botão RESTART na posição (0, 4)
        if (GUI.Button(new Rect(0, 4, 60, 26), "RESET"))
        {
            PlayerScore = 0;
            TotalScore = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        Scene scene = SceneManager.GetActiveScene();
        int pontosParaVencer = scene.name == "nivel1" ? 35 : 42;

        if (PlayerScore >= pontosParaVencer && (scene.name == "nivel1" || scene.name == "nivel2"))
        {
            if (!victoryScheduled)
            {
                victoryScheduled = true;
                nextScene = scene.name == "nivel1" ? "nivel2" : "Introducao";
                theBall.SendMessage("FreezeBall", null, SendMessageOptions.RequireReceiver);
                Invoke(nameof(LoadNextScene), 3f);
            }
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
        }
        if(PlayerLives <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "GAME OVER");

            if (!gameOverScheduled)
            {
                gameOverScheduled = true;
                theBall.SendMessage("FreezeBall", null, SendMessageOptions.RequireReceiver);
                Invoke(nameof(LoadIntroduction), 3f);
            }
        }
    }

    void LoadIntroduction()
    {
        FinalScore = TotalScore;
        PlayerWon = false;
        PlayerScore = 0;
        SceneManager.LoadScene("final");
    }

    void LoadNextScene()
    {
        if (nextScene == "Introducao")
        {
            FinalScore = TotalScore;
            PlayerWon = true;
            PlayerScore = 0;
            SceneManager.LoadScene("final");
        }
        else
        {
            PlayerScore = 0;
            SceneManager.LoadScene(nextScene);
        }
    }
    }
