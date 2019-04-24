using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverDam : MonoBehaviour {

    Vector3 centerPos;
    public Rigidbody[] rbs;

	// Use this for initialization
	void Start () {
        centerPos = transform.position;
        rbs = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExplodeDam(float force, float rad)
    {
        foreach(Rigidbody r in rbs)
        {
            r.AddExplosionForce(force*2.5f, centerPos, rad);
        }
        StartCoroutine(DeleteDam());
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(centerPos, 10.0f);
    }

    IEnumerator DeleteDam()
    {
        print("starting eradication procedure");
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }
}
