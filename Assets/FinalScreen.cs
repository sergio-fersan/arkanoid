using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public GUISkin layout;

    void OnGUI()
    {
        if (layout != null)
        {
            GUI.skin = layout;
        }

        string result = GameManager.PlayerWon ? "PLAYER WINS" : "GAME OVER";
        GUI.Label(new Rect(Screen.width / 2 - 150, 150, 400, 80), result);
        GUI.Label(new Rect(Screen.width / 2 - 150, 230, 400, 80), "SCORE: " + GameManager.FinalScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 100, 320, 200, 40), "VOLTAR"))
        {
            GameManager.PlayerScore = 0;
            GameManager.TotalScore = 0;
            GameManager.PlayerLives = 3;
            SceneManager.LoadScene("Introducao");
        }
    }
}