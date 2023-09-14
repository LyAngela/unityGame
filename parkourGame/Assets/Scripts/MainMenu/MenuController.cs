using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Start()
        {
            playButton.onClick.AddListener(Play);
            quitButton.onClick.AddListener(Quit);
        }

        private static void Play()
        {
            SceneManager.LoadScene("LevelOne");
        }

        private static void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}