using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// handkes scenechange based on whether players move of stage to the left (backwards in the game) or right (forward in the game)

public class SceneChangeScript : MonoBehaviour
{

    public Texture2D defaultCursor;
    public Texture2D hoverRight;
    public Texture2D hoverLeft;

    public Vector2 hotSpot = Vector2.zero; //
    public CursorMode curMode = CursorMode.Auto; //draws mouse with supported hardware

    public GameObject sceneCarpet;
    public static bool carpetDown;

    public int numberOfScenes;

    public float distanceMultiplier;
    public float sceneTransitionDelay;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, curMode); 
    }



    void OnMouseDown()
    {
        if (gameObject.tag == "carpetLeft" && SceneManager.GetActiveScene().buildIndex > 1)
        {
            StartCoroutine(sceneCarpetDownBack());
            Cursor.SetCursor(defaultCursor, hotSpot, curMode); //sets mouse to default look 
        }
        if (gameObject.tag == "carpetRight" && SceneManager.GetActiveScene().buildIndex < (numberOfScenes - 1))
        {
            StartCoroutine(sceneCarpetDownForward());
            Cursor.SetCursor(defaultCursor, hotSpot, curMode); //sets mouse to default look 
        }
    }

    void OnMouseEnter()
    {
        if (gameObject.tag == "carpetLeft" && SceneManager.GetActiveScene().buildIndex > 0)
        {
            Cursor.SetCursor(hoverLeft, hotSpot, curMode); //sets mouse to left mouse look
        }
        if (gameObject.tag == "carpetRight" && SceneManager.GetActiveScene().buildIndex < (numberOfScenes - 1))
        {
            Cursor.SetCursor(hoverRight, hotSpot, curMode); //sets mouse to right mouse look
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, curMode);

    }


    // following two function enact level loading and transition bepending on player moving back of forward in levels

    IEnumerator sceneCarpetDownBack()
    {
        if (!carpetDown)
        {
            for (int i = 0; i < 4; i++)
            {
                sceneCarpet.transform.Translate(Vector3.down * distanceMultiplier);
                yield return new WaitForEndOfFrame();

            }
            carpetDown = true;
            yield return new WaitForSeconds(sceneTransitionDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

            Debug.Log("sieg Heilo");
        }
        else
            yield break;


    }

    IEnumerator sceneCarpetDownForward()
    {
        if (!carpetDown)
        {
            for (int i = 0; i < 4; i++)
            {
                sceneCarpet.transform.Translate(Vector3.down * distanceMultiplier);
                yield return new WaitForEndOfFrame();
            }
            carpetDown = true;
            yield return new WaitForSeconds(sceneTransitionDelay);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("sieg Heil");

        }
        else
            yield break;


    }
}

