using UnityEngine;
using System.Collections;

public class FollowPlayerY : MonoBehaviour {

    public GameObject Player;
    public float posX = 8;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(posX, Player.transform.position.y+3f, 0f);


    }
}
