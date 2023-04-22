using UnityEngine;
using UnityEngine.SceneManagement;

public class Ondest : MonoBehaviour
{
    public GameObject slime;

    void OnDestroy()
    {
        if (gameObject == slime)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
        
    }
}
