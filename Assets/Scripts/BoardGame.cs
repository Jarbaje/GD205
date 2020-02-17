using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGame : MonoBehaviour
{
    //Player object. Assigned in Unity.
    public GameObject player;

    //Used to reset the player position in-game.
    Vector3 initPos;

    //Arrays for hazards and tokens. Size adjusted in Unity
    public Transform [] hazard,
                        token;

    //x, y, and z positions of player, hazards, and tokens.
    int x, z, y;
    int[] xh, zh,
        xt, zt;

    // Used to randomize the x, y, and z positions of the player.
    Vector3 pPos;

    //Used to control the sounds in the game
    public AudioSource move,
                       hazardSound,
                       tokenSound,
                       resetPlayer;
    


    // Start is called before the first frame update
    void Start()
    {   
        y = 1;
        x = Random.Range(0,8);
        z = Random.Range(0,8);
        xh = new int [hazard.Length];
        zh = new int [hazard.Length];
        xt = new int [token.Length];
        zt = new int [token.Length];

        pPos = new Vector3 (x,y,z);

        player.transform.position = pPos;
        initPos = player.transform.position;

        // Gives a random value to each x and z object in the xh and zh array
        // Initializes every object in the hazard array with a random position for each object.
        for (int i = 0; i < hazard.Length; i++) 
        {
             xh[i] = Random.Range(0,8);
             zh[i] = Random.Range(0,8);
             hazard[i].position = new Vector3 (xh[i], y, zh[i]);
        }

        // Gives a random value to each x and z object in the xt and zt array
        // Initializes every object in the token array with a random position for each object.
        for (int i = 0; i < token.Length; i++) 
        {
             xt[i] = Random.Range(0,8);
             zt[i] = Random.Range(0,8);
             token[i].position = new Vector3 (xt[i], y, zt[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && player.transform.position.x > 0) // Left
        {
            player.transform.position += new Vector3 (-1,0,0);
            move.Play();
        }

                if (Input.GetKeyDown(KeyCode.D )&& player.transform.position.x < 7) // Right
        {
            player.transform.position += new Vector3 (1,0,0);
            move.Play();
        }

                if (Input.GetKeyDown(KeyCode.W) && player.transform.position.z < 7) // Forward
        {
            player.transform.position += new Vector3 (0,0,1);
            move.Play();
        }

                if (Input.GetKeyDown(KeyCode.S) && player.transform.position.z > 0) // Back
        {
            player.transform.position += new Vector3 (0,0,-1);
            move.Play();
        }

                if (Input.GetKeyDown(KeyCode.E)) // Up
        {
            player.transform.position += new Vector3 (0,1,0);
            move.Play();
        }

                if (Input.GetKeyDown(KeyCode.Q)) // Down
        {
               player.transform.position += new Vector3 (0,-1,0);
               move.Play();
        }

         if (Input.GetKeyDown(KeyCode.Z)) // Reset position
        {
            player.transform.position = initPos;
            player.transform.localScale = new Vector3 (1,1,1);
            resetPlayer.Play();
            for (int i = 0; i < token.Length; i++)
            {
                if(token[i].position.y < 1)
                {
                    token[i].position += new Vector3 (0,3,0);
                }
            }
        }

        for (int i = 0; i < hazard.Length; i++) { //check for collision against in-game hazards

            if (hazard[i].position == player.transform.position) 
            {
                player.transform.position = initPos;
                hazardSound.Play();
            }
        }

        //check for collection of in-game tokens
        for (int i = 0; i < token.Length; i++) {

            if (token[i].position == player.transform.position) 
            {
                player.transform.localScale += new Vector3 (0,1,0);
                token[i].position += new Vector3 (0, -3, 0);
                tokenSound.Play();
            }
        }
    }
}