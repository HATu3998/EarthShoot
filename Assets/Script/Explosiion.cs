using UnityEngine;

public class Explosiion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float damage = 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject  );
    }
}
