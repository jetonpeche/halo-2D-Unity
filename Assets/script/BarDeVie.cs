using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarDeVie : MonoBehaviour
{
    public Slider sliderBouclier, sliderVie;
    public int vieActuelle;

    private int vieMax;
    private int bouclierMax, bouclierActuelle;

    void Start()
    {
        vieMax = vieActuelle = 100;
        bouclierMax = bouclierActuelle = 100;

        sliderVie.value = sliderVie.maxValue = 100;
        sliderBouclier.value = sliderBouclier.maxValue = 100;
    }

    public bool BouclierEstRecharger()
    {
        return bouclierMax == bouclierActuelle;
    }

    public bool EstEnVie()
    {
        return vieActuelle > 0;
    }

    public void EnleverVieBouclier(int degat)
    {
        if(bouclierActuelle > 0)
        {
            bouclierActuelle -= degat;
            if (bouclierActuelle < 0)
                bouclierActuelle = 0;

            sliderBouclier.value = bouclierActuelle;
        }
        else
        {
            vieActuelle -= degat;
            if (vieActuelle < 0)
                vieActuelle = 0;

            sliderVie.value = vieActuelle;
        }
    }

    public void AjouterBouclier()
    {
        if(bouclierActuelle < bouclierMax)
        {
            bouclierActuelle += 20;
            sliderBouclier.value = bouclierActuelle;

            if (bouclierActuelle > bouclierMax)
                bouclierActuelle = bouclierMax;
        }       
    }

    public void Soigner(int soin)
    {
        vieActuelle += soin;

        if (vieActuelle > vieMax)
            vieActuelle = 100;

        sliderVie.value = vieActuelle;
    }

    public void SoignerBouclier()
    {
        bouclierActuelle = bouclierMax;
        sliderBouclier.value = bouclierActuelle;
    }
}
