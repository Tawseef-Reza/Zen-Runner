using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CenterTouch : MonoBehaviour
{
    public HeroKnight _heroKnight;
    public GameObject canvas;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        _heroKnight = GameObject.Find("HeroKnight").GetComponent<HeroKnight>();
        text = GameObject.Find("text").GetComponent<TextMeshProUGUI>();
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAnim()
    {
        canvas.SetActive(true);
        _heroKnight.enabled = false;
        
        StartCoroutine(Finish());
    }
    IEnumerator Finish()
    {
        string breathin = "Breathe in for 10 seconds...";
        string breathout = "Breathe out!";
        for (int i = 0; i < breathin.Length; i++)
        {
            text.text = breathin.Substring(0, i + 1);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2);
        for (int i = breathin.Length-1; i >=0 ; i--)
        {
            text.text = breathin.Substring(0,i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(10);
        for (int i = 0; i < breathout.Length; i++)
        {
            text.text = breathout.Substring(0, i + 1);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2);
        for (int i = breathin.Length - 1; i >= 0; i--)
        {
            text.text = breathin.Substring(0, i);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        _heroKnight.enabled = true;
    }
}
