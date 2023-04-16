using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Intention : MonoBehaviour
{
    public void FocusButton()
    {
        SceneManager.LoadScene("Focus");
    }
    public void CalmButton()
    {
        SceneManager.LoadScene("Calm");
    }
}
