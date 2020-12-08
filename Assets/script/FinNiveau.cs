using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    public string nomNiveauSuivant;
    public bool menuDeFin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            if (menuDeFin)
            {
                DontDestroy.instance.SupprimerDeNePasDetruire();
                Inventaire.instance.SaveDataToMenuFin();
            }

            SceneManager.LoadScene(nomNiveauSuivant);
        }
    }
}
