using UnityEngine;
using System.Collections;
// manages reactions from on stage actors to player actions

public class PopUp : MonoBehaviour
{
    public float timer = 2f;
    public bool rotating = false;
    public bool moveUp = false;

    public Material heart;
    public Material exmark;
    public Material impatience;
    public Material angry;
    public Material happy;
	public Material dead;
    public MeshRenderer emojiHolder;

	// Use this for initialization
	void Start ()
	{
        emojiHolder = gameObject.GetComponentInChildren<MeshRenderer>();
	}

    public void setEmojiPopup(Material input, bool moveUp)                //Write setMojiPopup(one of the public emoji name, and "true") to change to the desired emoji and make it POP!
    {
        emojiHolder.material = input;

        if (moveUp)
        {
            StartCoroutine("movingUp");
        }

    }

    public void popUp(bool moveUp)                                        //pop ups the emoji                         
    {
        if (moveUp)
        {
            StartCoroutine("movingUp");
        }

    }

    public void setEmoji(Material input)                                   //sets the emoji without poping up
    {
        emojiHolder.material = input;
    }


    public IEnumerator movingUp()
    {
        moveUp = false;
        if(!rotating)
        {
            rotating = true;
            for (int i = 0; i <= 9; i++)
            {
                transform.Rotate(transform.rotation.x - 10, transform.rotation.y, transform.rotation.z);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(timer);
            for (int i = 0; i <= 9; i++)
            {
                transform.Rotate(transform.rotation.x + 10, transform.rotation.y, transform.rotation.z);
                yield return new WaitForEndOfFrame();
            }
            transform.rotation = Quaternion.Euler(90, transform.rotation.y, transform.rotation.z);
            rotating = false;
        }
        else
        {
            yield break;
        }
    }
}