using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    public int vitesse, forceSaut;
    public float radius;
    public Animator animator;
    public LayerMask layerMask;

    private bool estAuSol;
    private SpriteRenderer spriteRenderer;
    private Transform checkEstAuSol;
    private Rigidbody2D rb;
    private bool saute;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        // recupere le transform du GO enfant 0
        checkEstAuSol = gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        float mouvementH = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        if (estAuSol && Input.GetButtonDown("Jump"))
        {
            saute = true;
        }

        if (saute)
        {
            rb.AddForce(new Vector2(0, forceSaut));
            saute = false;
        }

        transform.Translate(new Vector2(mouvementH, 0));

        // fait pivoter le personnage dans la direction de deplacement
        Flip(mouvementH);

        // declanche l'animation de marche
        animator.SetFloat("vitesse", Mathf.Abs(mouvementH));
    }

    // pour la gestion de la physique
    private void FixedUpdate()
    {
        // verifie que le cercle est en contact le layerMask
        estAuSol = Physics2D.OverlapCircle(checkEstAuSol.position, radius, layerMask);
    }

    private void Flip(float _mouvement)
    {
        if (_mouvement > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(_mouvement < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
