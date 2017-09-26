using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerSlider : MonoBehaviour
{
    public Slider   sliderCustom;
    public Text     txtProgress;
    public int      iNumberScene;
    AsyncOperation  async;
    public int      iChange;

    void Start()
    {
        sliderCustom.minValue = 0;
        sliderCustom.maxValue = 100;
        sliderCustom.value = 0;
        StartCoroutine(LoadNewScene());
    }


    // Updates once per frame
    void Update()
    {
        sliderCustom.GetComponent<Slider>().value += iChange;
        txtProgress.GetComponent<Text>().text = sliderCustom.GetComponent<Slider>().value.ToString() + "%";
        
        if (sliderCustom.GetComponent<Slider>().value == sliderCustom.GetComponent<Slider>().maxValue)
        {
            async.allowSceneActivation = true;
        }
    }
    
    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene()
    {
        //yield return new WaitForSeconds(1);
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        async = SceneManager.LoadSceneAsync(iNumberScene);
        async.allowSceneActivation = false;
        Debug.Log("Progress OK");

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {            
            yield return null;
        }
    }
}