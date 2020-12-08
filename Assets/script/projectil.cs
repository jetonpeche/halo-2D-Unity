using System.Collections;
using UnityEngine;

public class projectil : MonoBehaviour
{
    public int vitesse;
    
    public int degatsProjectil, degatProjectilJoueur;
    public AudioClip son;
    public AudioSource audioSource;
    public string tagCible;

    // rend le champs public au niveau de unity
    [SerializeField][Header("initialise si projectil joueur")]
    private float tempsDeVolProjetil;
 
    [HideInInspector]
    public GameObject origine;
    private Rigidbody2D rb;

    private SpriteRenderer spOrigine;

    void Start()
    {
        // jouer l'audio
        audioSource.clip = son;
        audioSource.Play();

        if (tempsDeVolProjetil == 0)
            tempsDeVolProjetil = 2.5f;

        spOrigine = origine.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        // inserve la direction de tir en fonction flip et du tag
        if(!spOrigine.flipX && origine.tag == "ennemi" || spOrigine.flipX && origine.tag == "Player")
        {
            vitesse *= -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.velocity = new Vector2(vitesse, 0);
    }

    private void Update()
    {
        Destroy(gameObject, tempsDeVolProjetil);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // evite de tirer a travers les murs
        if (collision.gameObject.CompareTag("mur"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag(tagCible))
        {
            if(tagCible == "Player")
                VieJoueur.instance.SubirDegats(degatsProjectil);
            else
                collision.GetComponent<VieEnnemi>().SubirDegats(degatProjectilJoueur);

            Destroy(gameObject);
        }
    }
}
