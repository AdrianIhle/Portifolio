using UnityEngine;
using System.Collections;
// trigges and handles enemy horse of the knight 
public class EnemyHorse : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 movement;
    public Vector3 throwPlayer;
    public HorseRiding horseRiding;
    public Transform knightSprite;
    public GameObject Player;

    public bool Rotated;
    public bool dead;
    public bool rotLeft;
    int wait;

    void Start()
    {
        startPos = transform.position;
        transform.rotation = Quaternion.Euler(88, 0, 344.3795f);
        horseRiding = GameObject.FindGameObjectWithTag("Horse").GetComponent<HorseRiding>();
        Rotated = false;
        dead = false;
        movement = new Vector3(0.2f, 0, 0);
        throwPlayer = new Vector3(0, 0, -15);
        rotLeft = false;
        wait = 0;
        knightSprite = transform.GetChild(0);
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (horseRiding.isRiding && !dead)
        {
            if (!Rotated)
            {
                transform.Rotate(-5, 0, 0);
                wait++;
                if (wait == 18)
                {
                    Rotated = true;
                    transform.rotation = Quaternion.Euler(0, 0, 344.3795f);
                    wait = 0;
                }
            }
            if (Rotated)
            {
                transform.position += movement;

                if (!rotLeft) //Nekter å rotere
                {
                    knightSprite.Rotate(0, 0, 0.8f);
                    wait++;
                    if(wait == 20)
                    {
                        rotLeft = true;
                        wait = 0;
                    }

                }
                else if (rotLeft) //Nekter å rotere
                {
                    knightSprite.Rotate(0, 0, -0.8f);
                    wait++;
                    if (wait == 20)
                    {
                        rotLeft = false;
                        wait = 0;
                    }
                    
                }

            }

        }

        if (!horseRiding.isRiding || dead)
        {
            if (Rotated)
            {
                transform.Rotate(5, 0, 0);
                wait++;
                if (wait == 18)
                {
                    Rotated = false;
                    transform.rotation = Quaternion.Euler(88, 0, 344.3795f);
                    transform.position = startPos;
                    wait = 0;
					dead = false;
                }
            }
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            horseRiding.isRiding = false;
            Player.transform.position += throwPlayer;

    //        dead = true;
        }
    }

    public void attack()
    {
		dead = true;

    }

    public void useShovel()
    {
		dead = true;
    }

    public void useLute()
    {
		dead = true;
    }
}
