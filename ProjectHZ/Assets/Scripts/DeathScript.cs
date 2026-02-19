using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("—сылки на UI")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject CardBar;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        if (gameOverScreen == null)
        {
            Debug.LogError("GameOverScreen (Canvas/Panel) не назначен!", this);
            enabled = false;
            return;
        }
        gameOverScreen.SetActive(false);
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        else
            Debug.LogWarning(" нопка Restart не назначена в инспекторе");

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
        else
            Debug.LogWarning(" нопка Quit не назначена в инспекторе");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag("Enemy")) return;

        HideCardBar();
        ShowGameOver();
    }
    private void HideCardBar()
    {
        if (CardBar == null) return;

        CardBar.SetActive(false);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void ShowGameOver()
    {
        if (gameOverScreen == null) return;

        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void TriggerGameOverManually()
    {
        ShowGameOver();
    }
}