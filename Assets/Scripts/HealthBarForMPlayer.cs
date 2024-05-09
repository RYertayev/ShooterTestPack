using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarForMPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 0;
    public Slider slider;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
    }
    void SetHealth()
    {
        healthText.text = currentHealth.ToString();
    }
}
