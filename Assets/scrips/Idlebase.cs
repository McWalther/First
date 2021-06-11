using UnityEngine;
using UnityEngine.UI;

public class Idlebase : MonoBehaviour
{
    // Text
    public Text lutschertext;
    public Text lutschersec;
    public Text klickubgadetextbtn;
    public Text klickupgrade5textbtn;
    public Text klickupgrade10textbtn;
    public Text btext;
    public Text autoklicktext;
    public Text autoklick5text;
    public Text autoklick10text;
    public Text KlickUpgradetext;
    public Text AutoKlickUpgradetext;

    // Variabeln

    //Base
    public double lutscher;
    public double lutscherpsec;

    //Upgrades
    public double UpgAutocost;
    public double UpgAutocost5;
    public double UpgAutocost10;

    public double UpgKlickcost;
    public double UpgKlickcost5;
    public double UpgKlickcost10;

    public int Autolvl;
    public int UpgKlick;
    public int klick;
    public int Klicklvl;


    // Base Code
    public void Start()
    {
        Load();
    }

    public void Load()
    {
        lutscher = double.Parse(PlayerPrefs.GetString("lutscher", "0"));
        UpgAutocost = double.Parse(PlayerPrefs.GetString("UpgAutocost", "250")); ;
        UpgKlickcost = double.Parse(PlayerPrefs.GetString("UpgKlickcost", "100")); ;

        klick = PlayerPrefs.GetInt("klick", 1);
        Klicklvl = PlayerPrefs.GetInt("Klicklvl", 0);
        Autolvl = PlayerPrefs.GetInt("Autolvl", 0);
        UpgKlick = PlayerPrefs.GetInt("UpgKlick", 1);
    }

    public void Save()
    {
        PlayerPrefs.SetString("lutscher", lutscher.ToString());
        PlayerPrefs.SetString("UpgAutocost", UpgAutocost.ToString());
        PlayerPrefs.SetString("UpgKlickcost", UpgKlickcost.ToString());

        PlayerPrefs.SetInt("klick", klick);
        PlayerPrefs.SetInt("Klicklvl", Klicklvl);
        PlayerPrefs.SetInt("Autolvl", Autolvl);
        PlayerPrefs.SetInt("UpgKlick", UpgKlick);

    }

    public void Update()
    {
        lutscherpsec = Autolvl;


        //Schleife für Klickkosten

        int kk5 = 0;    // Variable für Schleife
        int kk10 = 0;

        UpgKlickcost5 = UpgKlickcost;
        UpgKlickcost10 = UpgKlickcost;
        UpgAutocost5 = UpgAutocost;
        UpgAutocost10 = UpgAutocost;

        while (kk5 < 6)
        {
            UpgKlickcost5 *= 1.07;
            UpgKlickcost5 += UpgKlickcost5;
            UpgAutocost5 *= 1.07;
            kk5++;
        }

        while (kk10 < 11)
        {
            UpgKlickcost10 *= 1.07;
            UpgAutocost10 *= 1.07;
            kk10++;
        }

        // Button Text

      
        lutschertext.text = "Lutscher: " + lutscher.ToString("F0");
        lutschersec.text = "Lutscher pro sec: " + lutscherpsec.ToString("F0");
        klickubgadetextbtn.text = "Klick Upgrade\n" + UpgKlickcost.ToString("F0") + "Lutscher\n+" + UpgKlick + "Lutscher pro Klick";
        klickupgrade5textbtn.text = "5x Upgrade\n" + UpgKlickcost5.ToString("F0") + " Lutscher";
        klickupgrade10textbtn.text = "10x Upgrade\n" + UpgKlickcost10.ToString("F0") + " Lutscher";
        autoklick5text.text = "5x Upgrade\n" + UpgAutocost5.ToString("F0") + " Lutscher";
        autoklick10text.text = "10x Upgrade\n" + UpgAutocost10.ToString("F0") + " Lutscher";
        autoklicktext.text = "Auoto Klick\n" + UpgAutocost.ToString("F0") + " Lutscher";
        btext.text = "Lutscher\n+" + klick;

        //Text

        AutoKlickUpgradetext.text = "Klic Upgrade Level: " + Klicklvl;
        KlickUpgradetext.text = "Auto Klick Upgrade Level: " + Autolvl;

        lutscher += lutscherpsec * Time.deltaTime;
        Save();
    }

    public void click()
    {
        lutscher += klick;
    }

    // Upgrade Code

        // Klkick Upgrade

    public void KaufenKlickupg()
    {
        if (lutscher >= UpgKlickcost)
        {
            lutscher -= UpgKlickcost;
            UpgKlickcost *= 1.07;
            Klicklvl++;
            klick++;
        }
    }

    public void KaufenKlickupg5()
    {
      
        if (lutscher >= UpgKlickcost5)
        {
            UpgKlickcost = UpgKlickcost5;
            lutscher -= UpgKlickcost5;
            Klicklvl += 5;
            klick += 5;
        }
    }

    public void KaufenKlickupg10()
    {
        if (lutscher >= UpgKlickcost)
        {
            UpgKlickcost = UpgKlickcost10;
            lutscher -= UpgKlickcost;
            Klicklvl += 10;
            klick += 10;
        }

    }

        //Autoklick Upgrade

    public void KaufenAutoklick()
    {
        if (lutscher >= UpgAutocost)
        {
            Autolvl++;
            lutscher -= UpgAutocost;
            UpgAutocost *= 1.07;
        }
    }

    public void KaufenAutoklick5()
    {
        if (lutscher >= UpgAutocost5)
        {
            UpgAutocost = UpgAutocost5;
            lutscher -= UpgAutocost5;
            Autolvl += 5;
        }
    }

    public void KaufenAutoklick10()
    {
        if (lutscher >= UpgAutocost10)
        {
            UpgAutocost = UpgAutocost10;
            lutscher -= UpgAutocost10;
            Autolvl += 10;
        }
    }

}