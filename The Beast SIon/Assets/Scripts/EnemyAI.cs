using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform target;

    public float speed = 3f;

    public int maxHealth = 3;
    public int currentHealth;

    public bool isInvincible = false;
    public float InvincTime = 0.5f;

    public Animator anim;

    public int points = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = new Vector2(position.x, position.y); // Maintain original z position
            // Optionally, make the enemy face the player
            LookAtPlayer();
        }
    }

    void LookAtPlayer()
    {
        if (target.position.x > transform.position.x)
        {
            // Target is to the right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (target.position.x < transform.position.x)
        {
            // Target is to the left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    public void Damage(int dmg)
    {
        if (isInvincible) return;

        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        //death
        if (currentHealth <= 0)
        {
            points += 2;
            Destroy(this.gameObject);
        }

        StartCoroutine(IFrame());
    }

    

    private IEnumerator IFrame()
    {
        isInvincible = true;

        anim.SetBool("isHit", true);

        yield return new WaitForSeconds(InvincTime);

        anim.SetBool("isHit", false);

        isInvincible = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<movement>() != null)
        {
            movement Player = collision.gameObject.GetComponent<movement>();

            Player.Damage(1);
        }
    }
}
