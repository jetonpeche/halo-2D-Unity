using System.Collections;
using UnityEngine;

public class AttaquerJoueur : MonoBehaviour
{
    public GameObject projectil, grenade;
    [Header("tempo entre deux tirs")]
    public float tirParSeconde;

    private bool tempo;

    void Update()
    {
        // tirer
        if(Input.GetMouseButton(0) && !tempo)
        {
            GameObject obj = Instantiate(projectil);
            obj.transform.position = transform.position;
            obj.GetComponent<projectil>().origine = gameObject;
            
            StartCoroutine(VitesseDeTir());
        }

        // lancer grenade
        if((Input.GetKeyDown(KeyCode.G) || Input.GetMouseButton(1)) && (Inventaire.instance.GetGrenade() > 0))
        {
            GameObject obj = Instantiate(grenade);
            obj.transform.position = transform.position;
            obj.GetComponent<Grenade>().origine = gameObject;

            Inventaire.instance.RetirerGrenade();
        }
    }

    // tempo entre chaque tir
    private IEnumerator VitesseDeTir()
    {
        tempo = true;
        yield return new WaitForSeconds(tirParSeconde);
        tempo = false;
    }
}
