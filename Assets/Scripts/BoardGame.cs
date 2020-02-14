using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{

    public GameObject player;
    Vector3 initPos;
    public Transform [] hazard;
    


    // Start is called before the first frame update
    void Start()
    {
        initPos = player.transform.position;
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

                if (Input.GetKeyDown(KeyCode.E)) // Up
        {
            player.transform.position += new Vector3 (0,1,0);
        }

                if (Input.GetKeyDown(KeyCode.Q)) // Down
        {
               player.transform.position += new Vector3 (0,-1,0);
        }

         if (Input.GetKeyDown(KeyCode.Z)) // Reset position
        {
            player.transform.position = new Vector3 (0,1,0);
        }

        for (int i = 0; i < hazard.Length; i++) {

            if (hazard[i].position == player.transform.position) 
            {
                player.transform.position = initPos;
            }
        }
    }
}
