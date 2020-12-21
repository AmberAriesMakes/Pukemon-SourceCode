using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void NewGame()
    {

        PlayerPrefs.DeleteKey("P_x");
        PlayerPrefs.DeleteKey("P_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void LoadGame()
        {
        SceneManager.LoadScene(1);

    }
}
