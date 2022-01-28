using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ODS_MotherShip_Health : MonoBehaviour
{
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public ODS_System_GameManager gameManager;
    public float invulnerabilityDuration = 15f;
    private float invulnerabilityTime;
    public bool invulnerable;
    public Image healthbar;

    void FixedUpdate()
    {
        healthbar.rectTransform.sizeDelta = new Vector2(healthbar.rectTransform.sizeDelta.x, currentHealth / 100);
        if (invulnerable)
        {
            if (invulnerabilityTime < invulnerabilityDuration)
            {
                invulnerabilityTime += 1;
            }
            else if(invulnerabilityTime >= invulnerabilityDuration)
            {
                invulnerable = false;
            }
        }

        if (currentHealth <= 0) 
        {
            gameManager.GameOver("SYSTEM OFFLINE");
        }
    }


    public void MotherShipTakeDamage(float amount)
    {
        if (!invulnerable)
        {
            currentHealth -= amount;
            BecomeInvulnerable();
        }
    }


    public void MotherShipHeal(float amount) 
    {
        currentHealth += amount;
    }

    private void BecomeInvulnerable()
    {
        invulnerabilityTime = 0;
        invulnerable = true;
    }
}
