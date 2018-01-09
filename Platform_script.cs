using UnityEngine;
using System.Collections;

public class Platform_script : MonoBehaviour {

	public Collider2D CharacterPosition;
    public Collider2D PlatEnabled;

	// Use this for initialization
	void Start ()
    {
        CharacterPosition = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        PlatEnabled = GetComponent<EdgeCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (CharacterPosition != null)
        {
			if (CharacterPosition.transform.position.y < transform.position.y)
            {
                PlatEnabled.enabled = false;
            }
			else if (CharacterPosition.transform.position.y > (transform.position.y + 0.5f))
            {
                PlatEnabled.enabled = true;
            }
        }
	
	}

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("s"))
            {
                PlatEnabled.enabled = false;
            }
        }
    }
}
