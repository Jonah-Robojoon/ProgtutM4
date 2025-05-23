using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Use string for scene name

    // Check if the player presses the spacebar
    // Load the "GameScene" using the LoadScene method
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad); // Pass the scene name
        }
    }
}