using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange : MonoBehaviour {

    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene ("Scenes/SampleScene", 1.0f);
    }
 
}
