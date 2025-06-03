using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public float health, maxHealth, width, height;
    [SerializeField] RectTransform healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetHealth(float health)
    {
        this.health = health;
        float newWidth = (health / maxHealth) * width;

        this.healthBar.sizeDelta = new Vector2(newWidth, height);
    }
}
