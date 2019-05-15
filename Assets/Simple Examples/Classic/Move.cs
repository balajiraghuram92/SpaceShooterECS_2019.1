using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classic
    {
    public class Move : MonoBehaviour
    {
        
        Vector3 localPos ;
        void Awake()
        {
            localPos = this.transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            localPos += transform.forward * GameController.Instance.moveSpeed * Time.deltaTime;

            if(localPos.z > GameController.Instance.topBounds)
                localPos.z = GameController.Instance.bottomBounds;

            this.transform.position = localPos;
        }
    }
}
