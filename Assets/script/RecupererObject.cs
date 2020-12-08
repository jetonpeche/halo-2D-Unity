using UnityEngine;

public class RecupererObject : MonoBehaviour
{
    public int soinInstantane;
    public BarDeVie barDeVie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("soin") && barDeVie.vieActuelle < 100)
        {
            barDeVie.Soigner(soinInstantane);
            Destroy(collision.gameObject);
        }  
        else if(collision.transform.CompareTag("piece"))
        {
            Inventaire.instance.AjouterScore();
            Destroy(collision.gameObject);
        }
        else if(collision.transform.CompareTag("grenade"))
        {
            Inventaire.instance.AjouterGrenade();
            Destroy(collision.gameObject);
        }
    }
}
