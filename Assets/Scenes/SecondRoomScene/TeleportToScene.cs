using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    public string nextSceneName;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("XR"))
        {
            SceneManager.LoadScene(nextSceneName);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextSceneName));
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}
