using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public Playerhealth player1;
    public Playerhealth player2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.dead == true && player2.dead == true) 
        {
            SceneManager.LoadScene("Defeat");
        }

    }
}
