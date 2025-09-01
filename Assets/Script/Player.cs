using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float maxHP = 100f;
    private float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameManager gameManager;
    private bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        

        currentHP = maxHP; updateHP();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseGameMenu();
            Debug.Log("pause");
        }
    }
    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * moveSpeed;
        if(playerInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }else if(playerInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if(playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        updateHP();
       
        if (currentHP <= 0)
        {
            Die();
        }
    }
    public void Heal(float heal)
    {
        if (currentHP < maxHP)
        {
            currentHP += heal;
            currentHP = Mathf.Min(currentHP, maxHP);
            updateHP();
        }
    }
    private void Die()
    {
        Debug.Log("Player Die called, HP = " + currentHP);
        Debug.Log("isDead = " + isDead);
        isDead = true;

        spriteRenderer.enabled = false;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("isRun", false);

        gameManager.GameOverMenu();
        Debug.Log("close");

    }
    private void updateHP()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
