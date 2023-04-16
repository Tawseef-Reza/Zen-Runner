using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 100;
    private bool isDead = false;

    public HealthBar healthBar;

    private Animator animator;

    public GameOverScreen gameOverScreen;

    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetTrigger("Death");
            StartCoroutine(DelayedDead(animator.GetCurrentAnimatorStateInfo(0).length));
        } else
        {
            if (!isDead)
            {
                animator.SetTrigger("Hurt");
            }
        }
    }

    IEnumerator DelayedDead(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        Destroy(gameObject);
        gameOverScreen.SetUp(scoreManager.score, scoreManager.highscore);
    }
}
