using UnityEngine;
using System.Collections;
using System;

public class DemoUIScript : MonoBehaviour {

	
    // ---------------TOAST METHODS BELOW-------------------


        //---------REGULAR TOASTS--------------
    public void ShowToastWarning()
    {
        Toast.Show(this, "This is a Warning toast.\nHaha blah blah!\nwhoop whoop!\nidk\nidk\nThat was a frkkin tall toast!", 3, Toast.Type.WARNING);
    }

    public void ShowToastMessage()
    {
        Toast.Show(this, "This is a Message toast.", 3, Toast.Type.MESSAGE);
    }

    public void ShowToastError()
    {
        Toast.Show(this, "This is an Error toast.", 3, Toast.Type.ERROR, 50);
    }


        //----------MIDDLE TOASTS-------------
    public void ShowToastWarningMid()
    {
        Toast.Show(this, "This is a Warning toast.\nHaha blah blah!\nwhoop whoop!\nidk\nidk\nThat was a frkkin tall toast!", 3, Toast.Type.WARNING, Toast.Gravity.CENTER);
    }

    public void ShowToastMessageMid()
    {
        Toast.Show(this, "This is a Message toast.", 3, Toast.Type.MESSAGE, Toast.Gravity.CENTER);
    }

    public void ShowToastErrorMid()
    {
        Toast.Show(this, "This is an Error toast.", 3, Toast.Type.ERROR, 50, Toast.Gravity.CENTER);
    }


        //----------TOP TOASTS-------------
    public void ShowToastWarningTop()
    {
        Toast.Show(this, "This is a Warning toast.\nHaha blah blah!\nwhoop whoop!\nidk\nidk\nThat was a frkkin tall toast!", 3, Toast.Type.WARNING, Toast.Gravity.TOP);
    }

    public void ShowToastMessageTop()
    {
        Toast.Show(this, "This is a Message toast.", 3, Toast.Type.MESSAGE, Toast.Gravity.TOP);
    }

    public void ShowToastErrorTop()
    {
        Toast.Show(this, "This is an Error toast.", 3, Toast.Type.ERROR, 50, Toast.Gravity.TOP);
    }


        //----------TOP-RIGHT TOASTS-------------
    public void ShowToastWarningTopRight()
    {
        Toast.Show(this, "This is a Warning toast.\nHaha blah blah!\nwhoop whoop!\nidk\nidk\nThat was a frkkin tall toast!", 3, Toast.Type.WARNING, Toast.Gravity.TOP_RIGHT);
    }

    public void ShowToastMessageTopRight()
    {
        Toast.Show(this, "This is a Message toast.", 3, Toast.Type.MESSAGE, Toast.Gravity.TOP_RIGHT);
    }

    public void ShowToastErrorTopRight()
    {
        Toast.Show(this, "This is an Error toast.", 3, Toast.Type.ERROR, 50, Toast.Gravity.TOP_RIGHT);
    }


        //----------BOTTOM-RIGHT TOASTS-------------
    public void ShowToastWarningBottomRight()
    {
        Toast.Show(this, "This is a Warning toast.\nHaha blah blah!\nwhoop whoop!\nidk\nidk\nThat was a frkkin tall toast!", 3, Toast.Type.WARNING, Toast.Gravity.BOTTOM_RIGHT);
    }

    public void ShowToastMessageBottomRight()
    {
        Toast.Show(this, "This is a Message toast.", 3, Toast.Type.MESSAGE, Toast.Gravity.BOTTOM_RIGHT);
    }

    public void ShowToastErrorBottomRight()
    {
        Toast.Show(this, "This is an Error toast.", 3, Toast.Type.ERROR, 50, Toast.Gravity.BOTTOM_RIGHT);
    }


        //--------TOAST DISMISS BUTTONS----------
    public void ToastDismissBtn()
    {
        Toast.Dismiss();
    }

    public void ToastDismissNextBtn()
    {
        Toast.DismissNext();
    }




    


    // ---------------MESSAGE-BOX METHODS BELOW-------------------


    public void BoxDismiss()
    {
        bool result = MessageBox.Dismiss();
        Debug.Log("Dismiss: " + result);
    }

    public void BoxOK()
    {
        MessageBox.ShowOKCancel("Hello MessageBox", "this is a demo message box.\n.\n.\n.\n.\nIt can have multiple lines.", MessageBox.Type.ERROR, CallbackOK);
    }

    private void CallbackOK(MessageBox.Result obj)
    {
        if(obj == MessageBox.Result.OK)
            Toast.Show(this, "Dismissed with OK pressed.", 2, Toast.Type.MESSAGE);
        else
            Toast.Show(this, "Dismissed manually.", 2, Toast.Type.ERROR);
    }
}
