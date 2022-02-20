using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class BackStart : MonoBehaviour {

    public void OnClickStartButton()
    {
        FadeManager.Instance.LoadScene ("Scenes/start/start scene", 0.5f);
    }
 
}
