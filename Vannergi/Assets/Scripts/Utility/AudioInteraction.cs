using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInteraction : MonoBehaviour
{
    private const string MIC_PERMISSION = "android.permission.RECORD_AUDIO";
    public AudioSource audioSource;
    public float soundForce;
    public float sensitivity = 100;
    public float loudness = 0;
    public float roarThreshold = 3;
    public float roarDuration;
    public float forceMultiplier;
    public bool playerIsRoaring;

    // Use this for initialization
    void Start()
    {
        //Acquires microphone, gives it null name, loops int, sets the sample time and the frequncy
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        //Ensures that the audio sources loops to always be available
        audioSource.loop = true;
        //Stops the script if the script can't find a Microphone
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //
        loudness = GetAveragedVolume() * sensitivity;

        //if the player produces a sounds above a certain level 
        if (loudness > roarThreshold)
        {
            playerIsRoaring = true;
            this.SendMessage("Roaring", true);
            StartCoroutine(PlayerRoaring());
        }
        else
        {
            playerIsRoaring = false;
            this.SendMessage("Roaring", false);
        }
    }
    //Aqcuires the average volume of all the samples at a given time in the audioClip
    private float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
    //Sets the force the player uses to move object with voice
    private IEnumerator PlayerRoaring()
    {
        soundForce = loudness * forceMultiplier;
        yield return new WaitForSeconds(roarDuration);
        soundForce = 0;
    }
    //Included in case of need to ask for permission
    public void AskPermission()
    {
        AndroidPermissionsManager.RequestPermission(new[] { MIC_PERMISSION }, new AndroidPermissionCallback(
            grantedPermission =>
            {

            },
            deniedPermission =>
            {

            }
        )
        );
    }
}
