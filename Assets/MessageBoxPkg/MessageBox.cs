using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class MessageBox {

    public enum Type
    {
        ERROR,
        WARNING,
        MESSAGE
    }

    public enum Result
    {
        OK,
        CANCEL,
        YES,
        NO,
        DISMISSED
    }

    public static bool isActive { get; private set; }

    static string title;
    static string message;
    static GameObject messageBoxCanvas;
    static Action<Result> resultCallback;

    /// <summary>
    /// Displays a MessageBox with an OK button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowOK(string title, string message, MessageBox.Type type, Action<Result> callback)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button2").SetActive(false);
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => OKClicked());
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with an OK button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowOK(string title, string message, MessageBox.Type type, Action<Result> callback, string okText)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = okText;    //settext for the button
        GameObject.Find("Button2").SetActive(false);
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => OKClicked());
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with an OKAY and CANCEL button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowOKCancel(string title, string message, MessageBox.Type type, Action<Result> callback)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Cancel";
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => CancelClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = "OK";
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => OKClicked());
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with an OKAY and CANCEL button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowOKCancel(string title, string message, MessageBox.Type type, Action<Result> callback, string okText, string cancelText)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = cancelText;
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => CancelClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = okText;
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => OKClicked());
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with a YES and NO button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowYesNo(string title, string message, MessageBox.Type type, Action<Result> callback)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Yes";
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => YesClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = "No";
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => NoClicked());
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with a YES and NO button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowYesNo(string title, string message, MessageBox.Type type, Action<Result> callback, string yesText, string noText)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = yesText;                       //set YES text
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => YesClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = noText;                        //set NO text
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => NoClicked());
        GameObject.Find("Button3").SetActive(false);
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with a YES, NO and CANCEL button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowYesNoCancel(string title, string message, MessageBox.Type type, Action<Result> callback)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = "Yes";
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => YesClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = "No";
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => NoClicked());
        GameObject.Find("Button3").GetComponentInChildren<Text>().text = "Cancel";
        GameObject.Find("Button3").GetComponent<Button>().onClick.AddListener(() => CancelClicked());
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    /// <summary>
    /// Displays a MessageBox with a YES, NO and CANCEL button.
    /// </summary>
    /// <param name="title">The messageBox title.</param>
    /// <param name="message">The content of the massage.</param>
    /// <param name="type">The type of MessageBox this is.</param>
    /// <param name="callback">The method to call when the user clicks a button.</param>
    public static void ShowYesNoCancel(string title, string message, MessageBox.Type type, Action<Result> callback, string yesText, string noText, string cancelText)
    {
        if (isActive)
            return;

        var prefab = Resources.Load("ScalingMessageBox");
        if (prefab == null)
        {
            Debug.LogAssertion("Prefab missing!");
            return;
        }
        messageBoxCanvas = (GameObject)UnityEngine.Object.Instantiate(prefab);
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = yesText;
        GameObject.Find("Button1").GetComponent<Button>().onClick.AddListener(() => YesClicked());
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = noText;
        GameObject.Find("Button2").GetComponent<Button>().onClick.AddListener(() => NoClicked());
        GameObject.Find("Button3").GetComponentInChildren<Text>().text = cancelText;
        GameObject.Find("Button3").GetComponent<Button>().onClick.AddListener(() => CancelClicked());
        GameObject.Find("MBTitle").GetComponent<Text>().text = title;
        GameObject.Find("MBMessage").GetComponent<Text>().text = message;
        resultCallback = callback;
        isActive = true;
    }

    private static void NoClicked()
    {
        isActive = false;
        GameObject.Destroy(messageBoxCanvas);
        if(resultCallback!=null)
            resultCallback(Result.NO);
    }

    private static void YesClicked()
    {
        isActive = false;
        GameObject.Destroy(messageBoxCanvas);
        if (resultCallback != null)
            resultCallback(Result.YES);
    }

    private static void OKClicked()
    {
        isActive = false;
        GameObject.Destroy(messageBoxCanvas);
        if (resultCallback != null)
            resultCallback(Result.OK);
    }

    private static void CancelClicked()
    {
        isActive = false;
        GameObject.Destroy(messageBoxCanvas);
        if (resultCallback != null)
            resultCallback(Result.CANCEL);
    }

    /// <summary>
    /// Static method to dismiss any active MessageBox in the scene.
    /// </summary>
    /// <returns>A boolean, TRUE if a MessageBox was indeed dismissed, FALSE if there was no active MessageBox.</returns>
    public static bool Dismiss()
    {
        if (isActive)
        {
            isActive = false;
            GameObject.Destroy(messageBoxCanvas);
            if (resultCallback != null)
                resultCallback(Result.DISMISSED);
            return true;
        }
        else
            return false;
    }

}
