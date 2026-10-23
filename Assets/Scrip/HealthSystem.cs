using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header ("configuracion de la vida")]
    [SerializeField] float maxHealth = 100f;
    private float currentHealth;
    public float CurrentHealth=> currentHealth;

    [SerializeField] private bool isDead;
    public bool IsDead
    {
        get => isDead;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(float amount)
    {
        if (isDead)return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        Debug.Log($"Salud Actual: {currentHealth}");
        if(currentHealth <= 0f)
        {
            Dead();
        }
    }
    
    private void Dead()
    {
        isDead = true;
        Debug.Log("Muerto");
        if(GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }
        if (isDead)
        {
            Time.timeScale = 0f;
            
        }

        
    }
    
}
