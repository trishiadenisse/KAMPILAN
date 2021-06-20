﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    
    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoadLevel = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            Debug.Log("Player collided");
            StartCoroutine(wait());
            LoadScene();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }



    void LoadScene()
    {
        if(useIntegerToLoadLevel) {
            SceneManager.LoadScene(iLevelToLoad);
        } else {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}

