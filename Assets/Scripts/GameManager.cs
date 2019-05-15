using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     private static GameManager _instance = null;

     public static GameManager Instance {
         get
         {
               return _instance;
         }
     }

    //common variables
    public float MoveSpeed = 3.0f;
    public float TopBounds = 3.0f;
    public float BottomBounds = -48.0f;
    public float LeftBounds = -20.5f;
    public float RightBounds = 20.5f; 

    public float count = 0;

     
     void Awake()
     {
         if(_instance != null && _instance != this)
            Destroy(_instance);
        else if(_instance == null)
        {
            _instance = this;
        }

     }
}
