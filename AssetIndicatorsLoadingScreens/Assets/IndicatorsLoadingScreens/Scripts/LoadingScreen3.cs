using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen3 : MonoBehaviour
{
    //Global
    public float    timeLoading;
    public Color    colorA;
    public Color    colorB;
    private float   timerLoading;

    //Tips
    public GameObject   buttonAction;
    public Text         textTip;
    public Text         txtLoading;
    public string[]     txtTips;
    public float        timeWaitTips;
    private float       timerTips;
    private int         tipsCurrent;

    //Backgrounds
    public GameObject   imageBackground;
    public Sprite[]     imagesBackground;
    public float        timeWaitBackground;
    private float       timerBackground;
    private int         imageCurrent;


    // Use this for initialization
    void Start ()
    {
        textTip.GetComponent<Text>().text = txtTips[0];
        buttonAction.SetActive(false);
        tipsCurrent = 0;
        imageCurrent = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        txtLoading.GetComponent<Text>().color = Color.Lerp(colorA, colorB, Mathf.PingPong(Time.time, 1));

        TimeTips();
        TimeLoading();
        TimeBackground();
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

    private void TimeTips()
    {
        timerTips += Time.deltaTime;

        if (timerTips >= timeWaitTips)
        {
            tipsCurrent++;

            if (tipsCurrent >= txtTips.Length)
            {
                tipsCurrent = 0;
            }

            textTip.GetComponent<Text>().text = txtTips[tipsCurrent];
            timerTips = 0;
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
