using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver;
    public static MenuGameOver instance;
    public Text textScoreTotal;

    private void Start()
    {
        instance = this;
    }

    public void GameOver()
    {
        menuGameOver.SetActive(true);
        float total = Inventaire.instance.GetScore() + GetComponent<Timer>().tempsTotal;
        textScoreTotal.text = total.ToString("f0");
        DontDestroy.instance.SupprimerDeNePasDetruire();
    }

    public void Rejouer()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("niveau1");    
        VieJoueur.instance.Respawn();
        menuGameOver.SetActive(false);
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1;
        DontDestroy.instance.SupprimerDeNePasDetruire();
        SceneManager.LoadScene("MenuPrincipal");   
    }

    public void Quitter()
    {
        Application.Quit();
    }


}
