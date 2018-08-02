﻿using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] showOnAwake;

    private void Awake()
    {
        foreach (GameObject o in showOnAwake)
        {
            o.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject o in showOnAwake)
        {
            o.SetActive(false);
        }
    }

}