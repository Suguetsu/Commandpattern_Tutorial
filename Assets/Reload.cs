
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    public void Load()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
