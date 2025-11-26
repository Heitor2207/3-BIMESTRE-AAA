using UnityEngine;

public class ObeliskAppearOnce : MonoBehaviour
{
    public Transform player;          
    public float distanciaAtivar = 5f;

    private SpriteRenderer sr;
    private Animator anim;
    private bool jaApareceu = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        sr.enabled = false;  // começa invisível

        // Garante que o obelisco não anima sozinho no começo
        anim.Play("Idle", 0, 0f);  
    }

    void Update()
    {
        if (jaApareceu)
            return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (dist <= distanciaAtivar)
        {
            sr.enabled = true;
            anim.SetTrigger("Appear");  // toca a animação de aparecer
            jaApareceu = true;
        }
    }
}