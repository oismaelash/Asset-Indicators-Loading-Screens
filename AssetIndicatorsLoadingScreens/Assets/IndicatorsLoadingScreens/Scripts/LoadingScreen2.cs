using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen2 : MonoBehaviour
{
    public GameObject   buttonAction;
    public Text         textTip;
    public Text         txtLoading;
    public string[]     txtTips;
    public float        timeWaitTips;
    public float        timeLoading;
    public Color        colorA;
    public Color        colorB;
    private float       timerLoading;
    private float       timerTips;
    private int         tipsCurrent;


	// Use this for initialization
	void Start ()
    {
        buttonAction.SetActive(false);
        tipsCurrent = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        txtLoading.GetComponent<Text>().color = Color.Lerp(colorA, colorB, Mathf.PingPong(Time.time, 1));

        TimeTips();
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
}
