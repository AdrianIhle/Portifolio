using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//resets game and reloads at main menu

public class ResetReload : MonoBehaviour {
    public string MainMenu;

	void Update ()
    {
        SceneManager.LoadScene(MainMenu);
        StartCoroutine(waiting());
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(0.3f);
        Application.LoadLevel(MainMenu);
    }
}
