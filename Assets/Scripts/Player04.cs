using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04 : MonoBehaviour
{
    public Animator anim;

    public Rigidbody rBody;

    float inputH, inputV;

    bool bRun;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();

        bRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("1") ) {
            anim.Play( "WAIT01", -1, 0f );
        }

        if( Input.GetKeyDown("2") ) {
            anim.Play("WAIT02", -1, 0f);
        }

        if( Input.GetKeyDown("3") ) {
            anim.Play("WAIT03", -1, 0f);
        }

        if( Input.GetKeyDown("4") ) {
            anim.Play("WAIT04", -1, 0f);
        }

        if( Input.GetMouseButtonDown(0) ) {
            int n = Random.Range(0, 2);

            if (0 == n) {
                anim.Play("DAMAGED00", -1, 0f);
            }
            else {
                anim.Play("DAMAGED01", -1, 0f);
            }
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        
        if( Input.GetKey(KeyCode.LeftControl) ) {
            bRun = true;
        }
        else {
            bRun = false;
        }

        if( Input.GetKey(KeyCode.Space) ) {
            anim.SetBool("jump", true);
        }
        else {
            anim.SetBool("jump", false);
        }

        anim.SetFloat("InputH", inputH);
        anim.SetFloat("InputV", inputV);
        anim.SetBool("run", bRun);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        if( moveZ <= 0f ) {
            moveX = 0;
        }
        else {
            if( bRun ) {
                moveX *= 3f;
                moveZ *= 3f;
            }
        }

        rBody.velocity = new Vector3(moveX, 0f, moveZ);        
    }
}
