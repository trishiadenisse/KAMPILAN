using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathRespawn : MonoBehaviour
{
    
    //public Transform spawnpoint;
    
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        
        hasDied = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(gameObject.transform.position.y < -4)
        {
               
            hasDied = true;
        }
        if(hasDied == true)
        {
       
          StartCoroutine("Die");
          // Respawn();
        } 
    }

   /* public void Respawn ()
    {
        this.transform.position =  spawnpoint.position;
    } */


    IEnumerator Die ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        yield return null;
    }
}
