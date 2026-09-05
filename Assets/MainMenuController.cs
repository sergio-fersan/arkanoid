using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("nivel1");
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
