using System.Collections;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public TMP_Text messageText;  
    public Canvas messageCanvas;  

    void Start()
    {
      
        messageCanvas.gameObject.SetActive(false);
    }

    
    public void DisplayMessage(string message)
    {
       
        messageText.text = message;

        messageCanvas.gameObject.SetActive(true);

        StartCoroutine(ClearMessage());
    }


    private IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(2f);

        messageCanvas.gameObject.SetActive(false);
    }
}
