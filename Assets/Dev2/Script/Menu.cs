using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject setings;
    public GameObject menus;
   

    public float timer;
    public bool ispuse; 
    public bool guipuse;

    private void Awake()
    {
        Ñontinue();
    }

    void Update()
    {
      
        Time.timeScale = timer; 
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false) 
        { 
            ispuse = true;
            Cursor.visible = true;
            Screen.lockCursor = false;
            menus.SetActive(true);
        } 
        else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true) 
        {
            Ñontinue();
        }
        if (ispuse == true) 
        {
            timer = 0; 
            guipuse = true; 
        }
        else if (ispuse == false)
        {
            timer = 1f; guipuse = false;  
        } 
    } 
     
    public void Ñontinue()
    {
        ispuse = false;
        menus.SetActive(false);
        setings.SetActive(false);
    }
    public void Seting()
    {
        setings.SetActive(true);

    }
    public void Colsed()
    {
        setings.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Exed()
    {
        Application.Quit();
    }

}
