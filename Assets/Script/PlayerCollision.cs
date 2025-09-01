using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Player player = GetComponent<Player>();
            player.TakeDamage(10);
        }
        else if (collision.CompareTag("usb")){
            gameManager.winGameMenu();
        }
        else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnegry();
            Destroy(collision.gameObject);
            audioManager.playEnergySound();
        }
    }
}
