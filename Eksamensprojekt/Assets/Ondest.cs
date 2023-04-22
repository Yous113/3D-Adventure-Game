using UnityEngine;
using UnityEngine.SceneManagement;

public class Ondest : MonoBehaviour
{
    void OnDestroy()
    {
        SceneManager.LoadScene(4);
    }
}
