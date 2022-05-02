using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
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
    private void OpenDoorMethod()
    {
        GetComponent<Animator>().SetBool("character_nearby", true);
    }
    private void CloseDoorMethod()
    {
        GetComponent<Animator>().SetBool("character_nearby", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("In");
            OpenDoorMethod();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Out");
            CloseDoorMethod();
        }
    }
}
