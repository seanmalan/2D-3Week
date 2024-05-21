using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public PlayerHunger playerHunger; // Reference to the PlayerHunger script
    public Image barImage; // Reference to the Image component of the hunger bar

    void Update()
    {
        if (playerHunger != null && barImage != null)
        {
            // Calculate fill amount based on player's current hunger
            float fillAmount = playerHunger.GetCurrentHunger() / playerHunger.maxHunger;
            barImage.fillAmount = fillAmount;
        }
    }
}
