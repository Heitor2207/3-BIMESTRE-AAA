using UnityEngine;

public class ObeliskAppearOnce : MonoBehaviour
{
    public Transform player;          
    public float distanciaAtivar = 5f;

    private SpriteRenderer sr;
    private bool jaApareceu = false;   // controla se já apareceu

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;  // começa invisível
    }

    void Update()
    {
        // Se já apareceu antes, nunca mais desaparece
        if (jaApareceu)
            return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (dist <= distanciaAtivar)
        {
            sr.enabled = true;
            jaApareceu = true;  // marca que já foi ativado permanentemente
        }
    }
}