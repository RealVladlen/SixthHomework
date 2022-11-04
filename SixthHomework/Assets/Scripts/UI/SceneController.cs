using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] Button _restartButton, _nextLevelButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(RestartLevel);
        _nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
