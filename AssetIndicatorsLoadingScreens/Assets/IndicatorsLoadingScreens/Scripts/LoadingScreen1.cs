using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen1 : MonoBehaviour
{
    public GameObject   buttonAction;
    public GameObject   imageBackground;
    public Text         txtLoading;
    public Sprite[]     imagesBackground;
    public float        timeWaitBackground;
    public float        timeLoading;
    public Color        colorA;
    public Color        colorB;
    private float       timerLoading;
    private float       timerBackground;
    private int         imageCurrent;


	// Use this for initialization
	void Start ()
    {
        buttonAction.SetActive(false);
        imageCurrent = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        txtLoading.GetComponent<Text>().color = Color.Lerp(colorA, colorB, Mathf.PingPong(Time.time, 1));

        TimeBackground();
        TimeLoading();    	    
	}

    private void TimeLoading()
    {
        timerLoading += Time.deltaTime;
        print("TimeLoading = " + timerLoading);

        if (timerLoading >= timeLoading)
        {
            txtLoading.enabled = false;
            buttonAction.SetActive(true);
        }
    }

    private void TimeBackground()
    {
        timerBackground += Time.deltaTime;

        if (timerBackground >= timeWaitBackground)
        {
            imageCurrent++;

            if (imageCurrent >= imagesBackground.Length)
            {
                imageCurrent = 0;
            }

            imageBackground.GetComponent<Image>().sprite = imagesBackground[imageCurrent];
            timerBackground = 0;
        }
    }
}
