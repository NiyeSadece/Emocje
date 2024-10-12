using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BerriesUI : MonoBehaviour
{
    private TextMeshProUGUI berriesText;
    void Start()
    {
        berriesText = GetComponent<TextMeshProUGUI>();
        berriesText.text = (GameManager.instance.NumberOfBerries / 2).ToString();
    }

    public void UpdateBerriesText()
    {
        berriesText.text = (GameManager.instance.NumberOfBerries / 2).ToString();
    }
}
