using UnityEngine;
using UnityEngine.UI;

public class Inventaire : MonoBehaviour
{
    [SerializeField]
    private int grenade, vie, score;
    public Text TextGrenade, textVie, textScore;

    // singleton (verifie qu'il y a qu'un inventaire dans le jeu)
    public static Inventaire instance;

    void Start()
    {
        score = 0;
        TextGrenade.text = grenade.ToString();
        textScore.text = score.ToString();
        textVie.text = vie.ToString();

        if (instance != null)
            Debug.Log("Il y a deja une instance de inventaire");

        instance = this;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetGrenade()
    {
        return grenade;
    }

    public int GetVieRestante()
    {
        return vie;
    }

    public void AjouterGrenade()
    {
        grenade++;
        TextGrenade.text = grenade.ToString();
    }

    public void RetirerGrenade()
    {
        grenade--;
        TextGrenade.text = grenade.ToString();
    }

    public void RetirerVie()
    {
        vie--;
        textVie.text = vie.ToString();
    }

    public void AjouterScore()
    {
        score++;
        textScore.text = score.ToString();
    }

    public void SaveDataToMenuFin()
    {
        SaveData.score = score;
        SaveData.timer = (int)GetComponent<Timer>().tempsTotal;
    }
}
