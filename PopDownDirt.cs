using UnityEngine;
using System.Collections;
//triggers event to specific player action
public class PopDownDirt : MonoBehaviour
{
    private bool rotating;
    GameObject skull;
    // Use this for initialization
    void Start()
    {
        skull = GameObject.FindGameObjectWithTag("Skull");
        skull.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            dirtFall();
        }
    }
    public void dirtFall()
    {
        StartCoroutine("dirtDown");
    }

    public IEnumerator dirtDown()
    {
        if (!rotating)
        {
            skull.SetActive(true);
            rotating = true;
            for (int i = 0; i <= 30; i++)
            {
                transform.Rotate(transform.rotation.x - 3, transform.rotation.y, transform.rotation.z);
                yield return new WaitForEndOfFrame();
            }

        }
        else
        {
            yield break;
        }
    }
}