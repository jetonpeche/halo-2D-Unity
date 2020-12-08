using System.Collections;
using UnityEngine;

public class AttaqueEnnemi : MonoBehaviour
{
    [Header("tempo entre deux tirs")]
    public float tirParSeconde;
    public GameObject projectil, grenade;
    public bool peutLancerGrenade, peutTirer;

    private Animator animator;
    private DeplacementEnnemi deplacementEnnemi;
    private SurveillanceEnnemi surveillanceEnnemi;

    // sauvegarde la vitesse de l'ennemi quand il s'arrete pour attaquer
    private int vitesseSave;

    // permet de tiré dans une boucle infini
    private bool isTrue, isTrueGrenade;
    
    void Start()
    {
        deplacementEnnemi = gameObject.transform.GetComponentInParent<DeplacementEnnemi>();
        animator = gameObject.transform.GetComponentInParent<Animator>();
        surveillanceEnnemi = gameObject.transform.GetComponentInParent<SurveillanceEnnemi>();

        if (deplacementEnnemi != null)
            vitesseSave = deplacementEnnemi.vitesse;
    }

    private IEnumerator Tirs()
    {
        while (isTrue)
        {
            GameObject obj = Instantiate(projectil);
            obj.transform.position = transform.parent.position;
            obj.GetComponent<projectil>().origine = transform.parent.gameObject;

            yield return new WaitForSeconds(tirParSeconde);
        }     
    }

    private IEnumerator LancerGrenade()
    {
        while(isTrueGrenade)
        {
            GameObject obj = Instantiate(grenade);
            obj.transform.position = transform.parent.position;
            obj.GetComponent<Grenade>().origine = transform.parent.gameObject;

            yield return new WaitForSeconds(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            // empeche l'ennemi d'etre poussé
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            if (surveillanceEnnemi != null)
                surveillanceEnnemi.isTrue = false;            

            if(deplacementEnnemi != null)
                deplacementEnnemi.vitesse = 0;

            if (animator != null)
                animator.SetBool("peutMarcher", false);

            if(peutTirer)
            {
                isTrue = true;
                StartCoroutine(Tirs());
            }
                
            if (peutLancerGrenade)
            {
                isTrueGrenade = true;
                StartCoroutine(LancerGrenade());
            }               
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            isTrue = isTrueGrenade = false;

            if (surveillanceEnnemi != null)
            {
                surveillanceEnnemi.isTrue = true;
                StartCoroutine(surveillanceEnnemi.Survaillance());
            }
                
            if (deplacementEnnemi != null)
                deplacementEnnemi.vitesse = vitesseSave;

            if (animator != null)
                animator.SetBool("peutMarcher", true);
        }
    }
}
