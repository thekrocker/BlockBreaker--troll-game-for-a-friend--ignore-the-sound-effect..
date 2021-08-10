using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void GetNextScene()
    {
        // Önce şuanki sahnenin indeksini öğrenir ve sonra +1 olarka diğer sahneye geçmesini sağlar. 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void GetStartScene()
    {
        //Butonlarda OnClick yerlerinde bunları seçtik. 
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
        

    }

    public void QuitScene()
    {
      
            Application.Quit();
        

    }
}
