using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public float health, maxHealth, width, height;
    [SerializeField] RectTransform healthBar;
 
    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        this.health = health;
        float newWidth = (health / maxHealth) * width; //Change RectTransform's value

        this.healthBar.sizeDelta = new Vector2(newWidth, height); //Set new RectTransform's value
    }
}
