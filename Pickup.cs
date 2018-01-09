using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;

            StartCoroutine(Eaten());
        }
    }

    IEnumerator Eaten()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}


