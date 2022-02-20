using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class CreateMove : MonoBehaviour {

    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene ("Scenes/make tree/make tree scene", 0.5f);
    }
 
}
