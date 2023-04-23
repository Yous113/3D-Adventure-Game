using UnityEngine;
using UnityEngine.SceneManagement;

public class Ondest : MonoBehaviour
{
    public Enemy slime;

    void Update()
    {
        if (slime.dead == true)
        {
            SceneManager.LoadScene(4);
        }
    }
}
