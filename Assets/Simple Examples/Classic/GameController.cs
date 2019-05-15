using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classic
{
    public class GameController : MonoBehaviour
    {
        //Move Speed variable is used for moving the Space ship with defined speed.
        public float moveSpeed = 3.0f;
        //The topBounds,bottomBounds,leftBounds,rightBounds are used for resetting 
        //the spaceship if it out of the Camera and for intializing the space ships 
        public float topBounds  = 16.0f;
        public float bottomBounds = 0.0f;
        public float leftBounds = 23.5f;
        public float rightBounds = -23.5f;

        //SpaceShip Prefab
        public GameObject spaceShipPrefab = null;

        //enemyCount is for counts of spaceship   
        public int enemyCount = 500;

        //Dynamic Ship Increaser which is check and multipled 
        //when the count is less than mentioned
        
        public int enemyCountIncrease = 1500;


        //FPS Counter
        FPSDisplay fps = null;

        int count = 0;
        private static GameController _instance = null;
        
        public static GameController Instance {
            get
            {
                return _instance;
            }
        }

        
        void Awake()
        {
            if(_instance == null)
                _instance = this;
            else if(_instance != this)
                Destroy(this.gameObject);
        }

        void Start()
        {
            fps = GetComponent<FPSDisplay>();

            CreateShips(enemyCount);
        }
        [HideInInspector]
        public Vector3 lastpos ;
        Vector3 pos;
        // Update is called once per frame 
        void CreateShips(int _count)
        {
             
            for(int i = 0 ;i < _count ; i++){
                    float xVal = UnityEngine.Random.Range(leftBounds,rightBounds);
                    float zVal = UnityEngine.Random.Range(0,10f);
                    pos = new Vector3(xVal,spaceShipPrefab.transform.position.y,zVal+bottomBounds);
                    Instantiate(spaceShipPrefab,pos,spaceShipPrefab.transform.rotation);
                    count++;                  
            }
            fps.setObjectCount(count.ToString());
        }

        void Update()
        {

            if(Input.GetKeyDown(KeyCode.C))
            {  
                CreateShips(enemyCountIncrease);
            }
        }
    }
}
