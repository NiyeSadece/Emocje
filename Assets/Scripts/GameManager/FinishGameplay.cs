using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishGameplay : MonoBehaviour
{

    public TMP_Text gameOverText;
    public TMP_Text berriesText;

    void Start()
    {

        int totalBerries = GameManager.instance.NumberOfBerries;

        totalBerries = totalBerries / 2;

        if (totalBerries < 50)
        {
            gameOverText.text = "Brawo, �wietnie Ci posz�o! Ale wygl�da na to, �e musisz jeszcze popracowa� nad technikami opanowania strachu.";
        }
        else
        {
            gameOverText.text = "Brawo, �wietnie Ci posz�o! Wygl�da na to, �e znasz ju� techniki radzenia sobie ze strachem.";
        }

        berriesText.text = "Tw�j wynik to " + totalBerries.ToString() + " jag�d!";

    } 
}
