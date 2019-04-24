using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeventhStageManager : LocalManager {

    public Transform oliveGeysir, oliveDam;
    public GeysirAnimScript geysir;
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayGeysir()
    {
        geysir.active = true;
        olive.transform.position = oliveGeysir.position;
        olive.transform.rotation = oliveGeysir.rotation;
        audioControl.PlaySound(0);
        print("geysir playing");
    }

    public void PlayDam()
    {
        olive.transform.position = oliveDam.position;
        olive.transform.rotation = oliveDam.rotation;
        audioControl.PlaySound(1);
        print("dam playing");
    }
}
