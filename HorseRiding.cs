using UnityEngine;
using System.Collections;
// handles player on hourse, movement and "animation"
public class HorseRiding : MonoBehaviour {

    public Transform horseTrans;
    public GameObject Player;

    public bool isRiding;
    public bool rotLeft;
    public int wait;

    Vector3 correctingPos;
    Quaternion correctingRot;

	void Start ()
    {
        horseTrans = gameObject.transform;
        isRiding = false;
        rotLeft = false;
        wait = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        correctingPos = new Vector3(0, 4.5f, 0);
        correctingRot = Quaternion.Euler(0, -90, 0);
	}

    void Update()
    {
        if (isRiding)
        {
            Player.transform.position = horseTrans.position + correctingPos;
            Player.transform.rotation = correctingRot;
        }
    }

    void FixedUpdate()
    {
        if (isRiding)
        {
            if (!rotLeft)
            {
                transform.Rotate(0, 0, 0.8f);
                wait++;
                if (wait == 25)
                {
                    rotLeft = true;
                    wait = 0;
                }

            }
            else if (rotLeft) 
            {
                transform.Rotate(0, 0, -0.8f);
                wait++;
                if (wait == 25)
                {
                    rotLeft = false;
                    wait = 0; 
                }
            }
        }
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Mount()
    {
        isRiding = true;
        Player.GetComponent<OnMouseMovement>().enabled = false;
        Player.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Unmount()
    {
        isRiding = false;
        Player.GetComponent<OnMouseMovement>().enabled = true;
        Player.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void attack()
    {

    }

    public void useCrown()
    {

    }

    public void showSkull()
    {

    }
}
