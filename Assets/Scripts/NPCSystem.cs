using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{ 
    bool playerDetected = false;

    // Update is called once per frame
    void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Dialogue started");
            var actor = GetComponent<Actor>();
            actor.SpeakTo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") playerDetected = true;
    }

    private void OnTriggerExit(Collider other)
    {
       playerDetected = false;

    }
}
