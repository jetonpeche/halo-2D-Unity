using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float tempsTotal;
    public Text textTimer;

    private void Start()
    {
        tempsTotal = 0;
    }

    private void Update()
    {
        tempsTotal += Time.deltaTime;

        string minutes = ((int)tempsTotal / 60).ToString();

        // f0 affiche pas les chiffres apres la virgule
        string secondes = (tempsTotal % 60).ToString("f0");
        textTimer.text = minutes + ":" + secondes;
    }
}
