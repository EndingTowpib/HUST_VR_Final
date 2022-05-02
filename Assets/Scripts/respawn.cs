using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public static int levelNum = 0;
    private Vector3 startPos;
    private Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    // 碰撞检测
    void OnTriggerEnter(Collider other) {
        if( other.tag == "Death" ) {
            transform.position = startPos;
            transform.rotation = startRot;

            GetComponent<Animator>().Play("LOSE00", -1, 0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
        }
        else if( other.tag == "checkpoint" ) {
            startPos = other.transform.position;
            startRot = other.transform.rotation;
            Destroy( other.gameObject );
        }
        else if( other.tag == "goal" ) {
            Destroy( other.gameObject );
            GetComponent<Animator>().Play("WIN00", -1, 0f);
            Invoke( "nextLevel", 2f );
        }
    }

    void nextLevel( )
    {
        levelNum ++;

        if( levelNum > 1 ) {
            levelNum = 0;
        }

        SceneManager.LoadScene( levelNum );
    }
	
    // Update is called once per frame
    void Update()
    {
        
    }
}
