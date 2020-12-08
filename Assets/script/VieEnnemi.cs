using System.Collections;
using UnityEngine;

public class VieEnnemi : MonoBehaviour
{
    public int vieMax;
    public int vieBouclier;
    public Animator animator;

    [Header("GO parent a detruire")]
    public GameObject objectActuel;
    [HideInInspector]
    public bool estDansZoneExplosion;

    private int vieActuelle;
    private DeplacementEnnemi deplacement;
    

    private void Start()
    {
        vieActuelle = vieMax;
        deplacement = GetComponent<DeplacementEnnemi>();
    }

    public bool EstenVie()
    {
        return vieActuelle > 0;
    }

    public void SubirDegats(int degats)
    {

        if (vieBouclier > 0)
        {
            vieBouclier -= degats;
        }
        else
        {
            vieActuelle -= degats;
        }

        if(vieActuelle <= 0)
        {
            if (animator != null)
                StartCoroutine(TempoAnim());
            else
                Destroy(objectActuel);
        }
    }

    // mort de l'ennemi
    private IEnumerator TempoAnim()
    {
        animator.SetBool("mourrir", true);

        // desactive le GO enfant 0
        transform.GetChild(0).gameObject.SetActive(false);

        if(deplacement != null)
            GetComponent<DeplacementEnnemi>().enabled = false;

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<BoxCollider2D>().isTrigger = true;

        yield return new WaitForSeconds(3);

        Destroy(objectActuel);
    }
}
