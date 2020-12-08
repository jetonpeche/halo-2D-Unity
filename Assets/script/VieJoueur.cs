using System.Collections;
using UnityEngine;

public class VieJoueur : MonoBehaviour
{
    public BarDeVie barDeVie;
    public float tempoChargementBouclier;

    [HideInInspector]
    public bool estDansZoneExplosion;
    public static VieJoueur instance;

    private bool bouclierRecharge, subirDegat;


    private void Start()
    {
        subirDegat = true;
        StartCoroutine(RechargerBouclier());

        if (instance != null)
            Debug.Log("il y a plus d'une instance de vie joueur");

        instance = this;
    }

    public void SubirDegats(int degat)
    {
        if(barDeVie.EstEnVie())
        {
            subirDegat = true;
            barDeVie.EnleverVieBouclier(degat);
        } 
        
        if(!barDeVie.EstEnVie())
        {          
            StartCoroutine(Mourrir());
            return;
        }

        if (barDeVie.BouclierEstRecharger())
            bouclierRecharge = true;
        else
            bouclierRecharge = false;       
    }

    public void Respawn()
    {
        transform.position = SaveData.positionChekpoint;
        barDeVie.Soigner(100);
        barDeVie.SoignerBouclier();
        GetComponent<DeplacementJoueur>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<AttaquerJoueur>().enabled = true;
    }

    private IEnumerator Mourrir()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;    
        GetComponent<DeplacementJoueur>().enabled = false;
        GetComponent<AttaquerJoueur>().enabled = false;

        GetComponent<Animator>().SetBool("mourrir", true);
        Inventaire.instance.RetirerVie();

        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("mourrir", false);

        if(Inventaire.instance.GetVieRestante() >= 0)
        {
            Respawn();
        }
        else
        {
            // arrete le temps
            Time.timeScale = 0;

            GetComponent<SpriteRenderer>().enabled = false;
            MenuGameOver.instance.GameOver();
        }
    }

    // verifie en permanance si le bouclier du joueur peut se recharger
    private IEnumerator RechargerBouclier()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);

            if (subirDegat)
            {
                subirDegat = false;
            }

            yield return new WaitForSeconds(1);

            while (!subirDegat && !bouclierRecharge)
            {
                barDeVie.AjouterBouclier();
                yield return new WaitForSeconds(tempoChargementBouclier);
            }
        }           
    }
}
