using UnityEngine;

public class Damager : MonoBehaviour
{
    public GameManager gameManager;
    public float damage;

    public float damageCooldown;
    private float initialCooldown = 2f;

    public void Start()
    {
        damageCooldown = initialCooldown;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown <= 0.0f)
            {
                Debug.Log("ROOT FIRE");
                gameManager.totalProgress -= damage;
                damageCooldown = initialCooldown;
            }
        }
    }
}
