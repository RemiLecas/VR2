using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    public string nextSceneName;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("XR"))
        {
            SceneManager.LoadSceneAsync(nextSceneName);
        }
    }
}
