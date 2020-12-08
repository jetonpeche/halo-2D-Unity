using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public int degat, forceLancer, tempoExplosion;
    public AudioSource audioSource;
    public AudioClip son;

    [HideInInspector]
    public GameObject origine;

    private SpriteRenderer spOrigine;
    private VieEnnemi vieEnnemi;

    private void Start()
    {
        audioSource.clip = son;
        spOrigine = origine.GetComponent<SpriteRenderer>();

        // inverse la force de lancer en fonction du tag et du flipX
        if (!spOrigine.flipX && origine.CompareTag("ennemi") || spOrigine.flipX && origine.CompareTag("Player"))
        {
            forceLancer *= -1;
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(forceLancer, 200));

        StartCoroutine(TempoAvantExplosion());
    }

    // defini si le joueur ou un ennemi est dans la zone explosion de la grenade
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
           VieJoueur.instance.estDansZoneExplosion = true;
        }
        
        if(collision.transform.CompareTag("ennemi"))
        {
            vieEnnemi = collision.GetComponent<VieEnnemi>();
            vieEnnemi.estDansZoneExplosion = true;
        }
    }

    // defini si le joueur ou un ennemi n'est plus dans la zone explosion de la grenade
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<VieJoueur>().estDansZoneExplosion = false;
        }

        if (collision.transform.CompareTag("ennemi"))
        {
            vieEnnemi.estDansZoneExplosion = false;
        }
    }

    private IEnumerator TempoAvantExplosion()
    {
        // -0.2 pour la tempo de synchro
        float tempo = tempoExplosion - 0.2f;

        yield return new WaitForSeconds(tempo);

        // lire l'audio puis attendre 0.2 pour synchronisé l'animation et l'audio
        audioSource.Play();
        yield return new WaitForSeconds(0.2f);

        // declanche animation explosion
        GetComponent<Animator>().SetTrigger("explosion");

        if (VieJoueur.instance.estDansZoneExplosion)
            VieJoueur.instance.SubirDegats(degat);

        if (vieEnnemi != null && vieEnnemi.estDansZoneExplosion)
            vieEnnemi.SubirDegats(degat);

        Destroy(gameObject, 1.2f);
    }
}
