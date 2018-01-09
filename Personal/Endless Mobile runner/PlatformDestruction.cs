using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestruction : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {


		if (other.tag == "Platform" || other.tag == "Bamboo" || other.tag == "Ramen")
            Destroy(other.transform.gameObject);

    }
}
