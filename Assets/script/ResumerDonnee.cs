using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumerDonnee : MonoBehaviour
{
    public Text textScore, textTimer;

    private void Start()
    {
        AfficherScore();
        AffichierTempsTotal();
    }

    private void AfficherScore()
    {
       textScore.text = SaveData.score.ToString();
    }

    private void AffichierTempsTotal()
    {
        int tempsTotal = SaveData.timer;

        string minutes = ((int)tempsTotal / 60).ToString();

        // f0 affiche pas les chiffres apres la virgule
        string secondes = (tempsTotal % 60).ToString("f0");
        textTimer.text = minutes + ":" + secondes;
    }
}
