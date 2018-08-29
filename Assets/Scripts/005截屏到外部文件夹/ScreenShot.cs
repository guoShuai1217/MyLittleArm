/*
 *		Description : 截屏到外部文件夹
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Forms;

public class ScreenShot : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnButPhotographNextClick();
    }

    private float fCurTime = 0;
    public void OnButPhotographNextClick()
    {
        if ((Time.time - fCurTime) > 0.3f)
        {
            StartCoroutine(Screenshots());
            fCurTime = Time.time;

        }
    }

    /// <summary>
    /// 截屏协程
    /// </summary>
    /// <returns></returns>
    IEnumerator Screenshots()
    {
        yield return new WaitForSeconds(0.2f);
        SaveFileDialog _SaveFileDialog = new SaveFileDialog();
        _SaveFileDialog.InitialDirectory = "C:\\";
        _SaveFileDialog.Filter = "Image Files(*.JPG;*.BMP;*.PNG)|*.JPG;*.BMP;*.PNG|All files (*.*)|*.*";
        DialogResult result = _SaveFileDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            string path = _SaveFileDialog.FileName;
            ScreenCapture.CaptureScreenshot(path);           
        }

    }


}
