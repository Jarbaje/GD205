using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{

    public GameObject player;
    public GameObject c3,
                      g1;

    //These are all the interactive spaces that will be in the game. Currently only C3 is configured.
    /*                a3,a7,
                      b5,
                      c1,c2,c3,c6,c8,
                      e2,e3,e4,e5,e7,
                      f1,f6,
                      g1,g3,g4,g6,g8, //g1 is a token space.
                      h1,h3,,h4,h8; // h1 is the goal and h3 is a token space.
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && player.transform.position.x > 0) // Left
        {
            player.transform.position += new Vector3 (-1,0,0);
        }

                if (Input.GetKeyDown(KeyCode.D )&& player.transform.position.x < 7) // Right
        {
            player.transform.position += new Vector3 (1,0,0);
        }

                if (Input.GetKeyDown(KeyCode.W) && player.transform.position.z < 7) // Forward
        {
            player.transform.position += new Vector3 (0,0,1);
        }

                if (Input.GetKeyDown(KeyCode.S) && player.transform.position.z > 0) // Back
        {
            player.transform.position += new Vector3 (0,0,-1);
        }

                if (Input.GetKeyDown(KeyCode.E) && player.transform.position.x == 7) // Up
        {
            player.transform.position += new Vector3 (0,1,0);
        }

                if (Input.GetKeyDown(KeyCode.Q) && player.transform.position.y > 0) // Down
        {
           if (player.transform.position.z == 0)
           {
               player.transform.position += new Vector3 (0,-1,0);
           } 
        }

         if (Input.GetKeyDown(KeyCode.Z)) // Reset position
        {
            player.transform.position = new Vector3 (0,1,0);
            player.transform.localScale = c3.transform.localScale;
        }

        //Lowers the player one unit on the Y-Axis
        if (player.transform.position.x == c3.transform.position.x && player.transform.position.z == c3.transform.position.z)
        {
            player.transform.position = new Vector3 (0,0,0);
        }

        //TBD
        if (player.transform.position.x == g1.transform.position.x && player.transform.position.z == g1.transform.position.z)
        {
            player.transform.localScale = new Vector3 (1,2,1);
        }
    }
}
