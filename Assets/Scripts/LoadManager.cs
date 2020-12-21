using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    Save playerPosData;

    private void Start()
    {
        playerPosData = FindObjectOfType<Save>();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitLevel()
    {
        playerPosData.PlayerPositionSave();
        SceneManager.LoadScene(0);
    }
}
