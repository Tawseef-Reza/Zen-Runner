using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;

    public float speed;

    private Transform player;

    private Animator animator;

    public float attackRange;

    private SpriteRenderer spriteRenderer;

    private bool flying = false;
    private bool bitingCD = false;

    private bool isBiting = false;
    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        animator = GetComponent<Animator>();

        speed = 0;
        animator.SetTrigger("Spawned");
        speed = 2;
        flying = true;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 scale = transform.localScale;
                    transform.localScale = scale;

            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Math.Abs(scale.x) * -1;
                spriteRenderer.flipX = true;
            } else
            {
                scale.x = Math.Abs(scale.x);
                spriteRenderer.flipX = false;
            }

            float distanceFromPlayer = Vector3.Distance(player.position, transform.position);

            if (distanceFromPlayer < attackRange && !isBiting)
            {
                isBiting = true;
                EnemyBiteSequence();
            }

            if (flying)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 1, transform.position.z), speed * Time.deltaTime);
            }
        }
        
    }


    private void EnemyBiteSequence()
    {
        speed = 0;
        animator.SetTrigger("Bite");
        StartCoroutine(DelayedBite(animator.GetCurrentAnimatorStateInfo(0).length));
        playerHealth.TakeDamage(damage);
        speed = 2;
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    IEnumerator DelayedBite(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        isBiting = false;
        print("Bite");
    }

}
