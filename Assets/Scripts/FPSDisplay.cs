using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text elementCount = null;
    public Text FPSCount = null;

    float deltaTime = 0;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime)*0.1f;
        updateFPS();
    }

    void updateFPS()
    {
        float msec = deltaTime * 1000f;
        float fps = 1.0f/deltaTime;
        FPSCount.text = string.Format("{0:00.}({1:00.0}ms)",fps,msec);
    }

    public void setObjectCount(string val)
    {
        elementCount.text = val;
    }
}
