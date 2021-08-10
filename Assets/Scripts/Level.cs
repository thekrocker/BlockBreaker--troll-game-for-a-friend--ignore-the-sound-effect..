﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //serialized for debugging 
    SceneLoader sceneLoader;


   
    public void CountBlocks()
    {

        breakableBlocks++;
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void BlockDestroyed()
    {

        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.GetNextScene();
        }
    }
    



}
