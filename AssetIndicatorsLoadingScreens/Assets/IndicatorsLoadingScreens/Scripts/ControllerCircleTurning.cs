using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerCircleTurning : MonoBehaviour
{
    public GameObject   goIndicatorTurn;
    public Text         txtProgress;
    public bool         turningRight;
    public int          speedRotation;
    public int          iNumberScene;
    AsyncOperation      async;
    private int         iProgress = 0;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(LoadNewScene());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (turningRight)
        {
            goIndicatorTurn.GetComponent<RectTransform>().Rotate(0, 0, -speedRotation + Time.deltaTime);
        }
        else
        {
            goIndicatorTurn.GetComponent<RectTransform>().Rotate(0, 0, speedRotation + Time.deltaTime);
        }

        iProgress++;
        print("Progress = " + iProgress);

        txtProgress.GetComponent<Text>().text = iProgress.ToString() + "%";
        
        if (iProgress == 100)
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
