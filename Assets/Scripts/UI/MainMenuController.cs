using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ACG
{
    public class MainMenuController : MonoBehaviour
    {
        public Button StartButton;
        public Button QuitButton;

        void Awake()
        {
            if (StartButton) StartButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
            if (QuitButton) QuitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}