using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercam : MonoBehaviour {

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject playerrocket;
    
    public bool followPlayer = true;
    float xMin = -19.59f;
    float xMax = 13.59f;
    float yMin = -28;
    float yMax = 6;

    void LateUpdate()
    {
        Vector2 position;
        if(followPlayer) {
            position.x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            position.y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        }
        else {
            position.x = Mathf.Clamp(transform.position.x, xMin*2, xMax*2);
            position.y = Mathf.Clamp(playerrocket.transform.position.y, yMin, yMax * 4f);
        }
    
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
