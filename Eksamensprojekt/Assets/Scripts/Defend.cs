using UnityEngine;

public class Defend : MonoBehaviour
{
    private CharacterController controller;
    public bool shieldactive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            shieldactive = true;
            Debug.Log("Defend button pressed");
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            shieldactive = false;
            Debug.Log("Defend button released");
        }
    }
}
