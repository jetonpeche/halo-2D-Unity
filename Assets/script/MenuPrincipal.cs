using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("niveau1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
