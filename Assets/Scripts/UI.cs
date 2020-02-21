using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text playerMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMessage.text = "WASD for movement. \nEQ for Up and Down. \nZ to reset position.\n" + Time.time;
    }
}
