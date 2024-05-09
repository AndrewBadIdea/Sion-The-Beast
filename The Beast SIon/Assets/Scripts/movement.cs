using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D player;
    public Animator animator;
    private Vector3 originalScale;
    public bool isInvinc = false;
    public float InvincTime = 1.5f;

    public float MoveSpeed = 6f;


    Vector2 Move;


    public int maxHealth = 3;
    public int currentHealth;
    public HpText hpTxt;
    public bool isDead = false;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        currentHealth = maxHealth;
        hpTxt.UpdateHp(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float isMove = 0;

        Move.x = Input.GetAxisRaw("Horizontal");
        Move.y = Input.GetAxisRaw("Vertical");

        Move.Normalize();
        player.velocity = Move * MoveSpeed;

        

        if (Move != Vector2.zero || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Move != Vector2.zero)
              isMove = 1;

            //transform.localScale = new Vector3(Mathf.Sign(Move.x) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            transform.localScale = new Vector3(Mathf.Sign(Input.GetKey(KeyCode.RightArrow) ? 1 : (Input.GetKey(KeyCode.LeftArrow) ? -1 : Move.x)) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        animator.SetFloat("speed", isMove);
    }

    public void Damage(int dmg)
    {
        if (isInvinc) return;

        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        hpTxt.UpdateHp(currentHealth);

        //death
        if (currentHealth <= 0)
        {
            player.constraints = RigidbodyConstraints2D.FreezeAll;

            isDead = true;

            animator.SetBool("isDead", isDead);

            StartCoroutine(deathAnim());
            return;
        }

        StartCoroutine(IFrame());
    }
    private IEnumerator IFrame()
    {
        isInvinc = true;

        yield return new WaitForSeconds(InvincTime);

        isInvinc = false;
    }

    IEnumerator deathAnim()
    {
        yield return new WaitForSeconds(5f);

        Debug.Log("dead");
        SceneManager.LoadScene("MainMenu");
    }
    public void Heal()
    {
        currentHealth++;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        hpTxt.UpdateHp(currentHealth);
    }
}
