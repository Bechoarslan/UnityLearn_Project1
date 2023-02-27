using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCarCameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 4, -10);
    private Vector3 newCameraPosition = new Vector3(0, 3, -1);
    private bool isChanged = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged == false && Input.GetKeyDown(KeyCode.Space))
        {
            isChanged = true;
            offset = new Vector3(0, 4, -10);
        }
        else if (isChanged == true && Input.GetKeyDown(KeyCode.Space))
        {
            isChanged = false;
            offset = new Vector3(0, 3, -1);
        }
        transform.position = player.transform.position + offset;
    }
}
    

