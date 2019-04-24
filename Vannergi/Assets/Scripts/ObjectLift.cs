using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLift : MonoBehaviour {
    public GameObject platform;
    public GameObject ball;
    public GameObject cube;

    [SerializeField]
    Transform topPos;
    [SerializeField]
    Transform botPos;

    public bool moveUp;
    public bool moveDown;

	// Use this for initialization
	void Start () {
        ball.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(moveUp)
        {
            MovePlatform(topPos.position, 1.1f);
            if (Vector3.Magnitude(topPos.position - platform.transform.position)< 0.1f)
                moveUp = false;
        }
        else if (moveDown)
        {
            MovePlatform(botPos.position, 1.1f);
            if (Vector3.Magnitude(botPos.position - platform.transform.position) < 0.1f)
                moveDown = false;
        }
	}

    void ActivateBall()
    {
        ball.SetActive(true);
    }

    void MovePlatform(Vector3 pos, float speed)
    {
        platform.transform.position = Vector3.Lerp(platform.transform.position, pos, speed * Time.deltaTime);
    }

    public IEnumerator LiftBall(float duration)
    {
        ActivateBall();
        ball.layer = platform.layer;
        yield return new WaitForSeconds(0.1f);
        moveUp = true;
        yield return new WaitForSeconds(duration);
        ball.layer = cube.layer;
        moveDown = true;
    }
}
