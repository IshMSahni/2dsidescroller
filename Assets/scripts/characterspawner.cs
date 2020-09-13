using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterspawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players; //if you want to create more than one in the future
    void Start()
    {
        Instantiate(players[0], Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
