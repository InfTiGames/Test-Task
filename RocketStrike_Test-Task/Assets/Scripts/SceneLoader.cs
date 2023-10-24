using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    /// <summary>
    /// Loads main game scene
    /// </summary>
    public void LoadNextScene() {
        int _sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(_sceneIndex);
    }
}