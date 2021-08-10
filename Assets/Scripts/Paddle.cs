using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached references

    GameStatus theGameStatus;
    Ball theBall;
    

    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
            
                                                                                                    // Hangi width olursa olsun algılamasını sağlar. 0 ile 1 arası konsola yazdırır. Ve Size unit ile çarpılır.  Böylece ekran X axisinde 16'ya bölünür. En sol 1, en sağ 16 positionunda olur. 
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);                          // Vector2 demek X VE Y eksenini tutan vektör demek. 3 olsaydı Z de dahil olurdu. Alttaki kodda ise Paddle'ımızı pozisyonunu 10X, 4Y konumuna getirdik. new Vector2(10f, 4f); 
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);  //Clamp methodunun içindeki mousePos -- mouse'ın nerede olduğunu gösteriyor. Bu yüzden üsteki vektörde onu yazmaya gerek kalmadı. 
            transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {

            return theBall.transform.position.x;
        }

        else
        {

                //Eğer auto play açıksa, paddle topu takip eder, değilse mouseumuzu. Hangi width olursa olsun algılamasını sağlar. 0 ile 1 arası konsola yazdırır. Ve Size unit ile çarpılır.  Böylece ekran X axisinde 16'ya bölünür. En sol 1, en sağ 16 positionunda olur. 
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;

        }

    }
}
