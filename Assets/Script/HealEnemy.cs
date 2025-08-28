using UnityEngine;

public class HealEnemy : Enemy {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float healValue = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
                
            }
        }
    }
    protected override void Die()
    {
        HealPlayer();
        base.Die();
    }
     private void HealPlayer()
    {
        if(player != null)
        {
            player.Heal(healValue);
        }
    }
}
