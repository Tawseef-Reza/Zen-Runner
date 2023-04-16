using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 100;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            animator.SetTrigger("Death");
            StartCoroutine(DelayedDead(animator.GetCurrentAnimatorStateInfo(0).length));
        } else
        {
            animator.SetTrigger("Hurt");
        }
    }

    IEnumerator DelayedDead(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        Destroy(gameObject);
    }
}
