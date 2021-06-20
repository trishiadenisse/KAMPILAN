using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
   public void BackToMainMenu (){
		  SceneManager.LoadScene(1);
   }

   public void MactanShrine (){
		  SceneManager.LoadScene(9);
   }

   void Bridge (){
		  SceneManager.LoadScene(11);
   }

   void Church (){
		  SceneManager.LoadScene(13);
   }

   void Sea (){
		  SceneManager.LoadScene(15);
   }

   void Airport (){
		  SceneManager.LoadScene(17);
   }

   void Guitar (){
		  SceneManager.LoadScene(19);
   }
}
