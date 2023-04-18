using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
public class Defend : MonoBehaviour
{
    [Header("DefendVariables")]
    public bool shieldactive = false;
    private bool defending;
    [SerializeField] private PlayerController movementScript;
    private Animator animator;
    public float defendDuration;

    [Header("Upgrade")]
    private int sticksneeded;
    private int gemsneeded;
    [SerializeField] private TMP_Text sticksneededText;
    [SerializeField] private TMP_Text gemsneededText;
    [SerializeField] Inventory inventory;
    [SerializeField] ShopManagerScript shopUI;
    private void Start()
    {
        animator = GetComponent<Animator>();
        sticksneeded = PlayerPrefs.GetInt("Sticksneeded", 5);
        gemsneeded = PlayerPrefs.GetInt("Gemsneeded", 2);
        defendDuration = PlayerPrefs.GetFloat("DefendDuration", 1.5f);
        UpdateText();
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        defending = context.action.IsPressed();
        if (defending == true && shieldactive == false)
        {
            shieldactive = true;
            animator.SetBool("IsDefending", true);
            movementScript.enabled = false;
            Debug.Log("Defend button pressed");
            StartCoroutine(DisableShieldAfterDuration(defendDuration));
        } 
        
        else if (defending == false)
        {
            shieldactive = false;
            animator.SetBool("IsDefending", false);
            Debug.Log("Defend button released");
            movementScript.enabled = true;
        }
    }

    IEnumerator DisableShieldAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        shieldactive = false;
        animator.SetBool("IsDefending", false);
        movementScript.enabled = true;
        Debug.Log("Shield disabled after " + duration + " seconds");
    }

    public void UpgradeShield()
    {
        if (inventory.sticks > sticksneeded & inventory.gems > gemsneeded)
        {
            inventory.sticks -= sticksneeded;
            inventory.gems -= gemsneeded;
            defendDuration += 2;
            sticksneeded *= 2;
            gemsneeded *= 2;
            PlayerPrefs.SetFloat("DefendDuration", defendDuration);
            PlayerPrefs.SetInt("Sticksneeded", sticksneeded);
            PlayerPrefs.SetInt("Sticksneeded", gemsneeded);
            shopUI.UpdateUI();
            UpdateText();
        }

    }
    private void UpdateText()
    {
        sticksneededText.text = sticksneeded.ToString();
        gemsneededText.text = gemsneeded.ToString();

    }


}
