using UnityEngine;
using UnityEngine.UI;

public class ThoughtTextScript : MonoBehaviour
{
    public Text thoughtText;

    public void SetThoughtText(string text)
    {
        thoughtText.text = text;
    }
}