using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _avotorsButton;
    [SerializeField] private Button _exitButton;
    void Start()
    {
        _startButton.onClick.AddListener(loadGameScene);
    }

    private void loadGameScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
