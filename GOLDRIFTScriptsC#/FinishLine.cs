using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject finishPanel;
    public GameObject goldsText;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        CompleteRace();
    }
    public void CompleteRace ()
    {
        goldsText.SetActive(false);
        finishPanel.SetActive(true);
    }
}
