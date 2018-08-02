using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string optionScene;
    public GameObject[] showOnAwake;

    private void Awake()
    {
        foreach (GameObject o in showOnAwake)
        {
            o.SetActive(true);
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

}