using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKill : MonoBehaviour
{
    
    public GameObject Plane;
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
        Panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Plane.SetActive(false);
        gameObject.SetActive(false);
        Panel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
