using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator anim;

    private GameObject player;

    public float distanciaDeVisao = 10;
    public float velocidade = 5;

    private CircleCollider2D col;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        col = GetComponent<CircleCollider2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distanciaDeVisao = col.radius;

        if (player != null)
        {
            float dx = player.transform.position.x - transform.position.x;
            float dy = player.transform.position.y - transform.position.y;

            bool dentroDaVisao =
                Mathf.Abs(dx) < distanciaDeVisao &&
                Mathf.Abs(dy) < distanciaDeVisao;

            if (dentroDaVisao)
            {
                // anda para a direita
                if (dx > 0)
                {
                    rb.velocity = new Vector2(velocidade, rb.velocity.y);
                    spriteRenderer.flipX = false;
                }
                // anda para a esquerda
                else if (dx < 0)
                {
                    rb.velocity = new Vector2(-velocidade, rb.velocity.y);
                    spriteRenderer.flipX = true;
                }
            }
            else
            {
                // não viu o player = Idle
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            // envia velocidade horizontal pro Animator
            float velAtual = Mathf.Abs(rb.velocity.x);
            anim.SetFloat("Speed", velAtual);
        }
    }
}

