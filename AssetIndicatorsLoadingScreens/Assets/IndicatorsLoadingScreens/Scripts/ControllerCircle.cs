using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerCircle : MonoBehaviour
{
    public Image    CircleImage;
    public Text     txtProgress;
    public int      iNumberScene;
    AsyncOperation  async;

    private void Start()
    {
        CircleImage.type = Image.Type.Filled;
        CircleImage.fillMethod = Image.FillMethod.Radial360;
        CircleImage.fillAmount = 0;
        StartCoroutine(LoadNewScene());
    }

    // Update is called once per frame
    void Update()
    {
        CircleImage.GetComponent<Image>().fillAmount += 0.01f;
        txtProgress.GetComponent<Text>().text = ((int)(CircleImage.GetComponent<Image>().fillAmount * 100)).ToString() + "%";

        //1 = 100%
        if (CircleImage.GetComponent<Image>().fillAmount == 1)
        {
            async.allowSceneActivation = true;
        }
    }

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
