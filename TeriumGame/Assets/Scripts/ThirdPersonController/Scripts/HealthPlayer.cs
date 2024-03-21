using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;


    [SerializeField] private Slider healthBar;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // If health is zero or less, deactivate player
            DeactivateScript();
            Destroy(gameObject);
        }

        UpdateHealthBar();
     
    }

    public void DeactivateScript()
    {
        StartCoroutine(DeactivatePlayerGameObject());
    }

    IEnumerator DeactivatePlayerGameObject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void UpdateHealthBar()
    {
        // Calculate the health percentage
        float healthPercentage = currentHealth / maxHealth;
        // Update the slider value
        healthBar.value = healthPercentage;
    }

}
