using UnityEngine;
using UnityEngine.SceneManagement;

namespace ACG
{
    public class BootLoader : MonoBehaviour
    {
        void Start() => SceneManager.LoadScene("MainMenu");
    }
}