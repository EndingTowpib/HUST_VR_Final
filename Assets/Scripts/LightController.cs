using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private bool enterCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    bool k=GetComponent<Animator>().GetBool("character_nearby");
        //    GetComponent<Animator>().SetBool("character_nearby", !k);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("On");
            GetComponentInChildren<Light>().intensity = 1.6f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Off");
            GetComponentInChildren<Light>().intensity = 0;
        }
    }
}
