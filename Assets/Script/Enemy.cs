using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected float enemyMove = 1f;
    protected Player player;
    [SerializeField] protected float maxHP = 50f;
    protected float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;
  protected virtual  void Start()
    {
        player = FindFirstObjectByType<Player>();
        currentHP = maxHP;
        updateHpBar();
    }
    protected void MoveToPlayer()
    {
        if(player != null)
        {
    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMove * Time.deltaTime);
            FlipEnemy();
        }
    }
    protected void FlipEnemy()
    {
        if (player != null)
        {
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }

    // Update is called once per frame
 protected virtual   void Update()
    {
        MoveToPlayer();
    }
  public virtual void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        updateHpBar();
        if (currentHP <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void updateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
