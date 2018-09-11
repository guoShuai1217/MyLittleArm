
using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机跟随
/// </summary>
public class CameraCtrl : MonoBehaviour 
{
    public static CameraCtrl Instance;

    /// <summary>
    /// 控制摄像机上下
    /// </summary>
    [SerializeField]
    private Transform m_CameraUpAndDown;

    /// <summary>
    /// 摄像机缩放父物体
    /// </summary>
    [SerializeField]
    private Transform m_CameraZoomContainer;

    /// <summary>
    /// 摄像机容器
    /// </summary>
    [SerializeField]
    private Transform m_CameraContainer;

    void Awake()
    {
        Instance = this;
        Init();
    }

   
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        m_CameraUpAndDown.transform.localPosition = new Vector3(0, Mathf.Clamp(m_CameraUpAndDown.transform.localPosition.y, 1f, 20f), 0);
    }

    /// <summary>
    /// 设置摄像机旋转
    /// </summary>
    /// <param name="type">1=左 0=右</param>
    public void SetCameraRotate(int type)
    {
        transform.Rotate(0, 40 * Time.deltaTime * (type == 0 ? -1 : 1), 0);
    }

    /// <summary>
    /// 设置摄像机上下 0=上 1=下
    /// </summary>
    /// <param name="type"></param>
    public void SetCameraUpAndDown(int type)
    {
        m_CameraUpAndDown.transform.Translate(Vector3.up * 30 * Time.deltaTime * (type == 1 ? -1 : 1));
        m_CameraUpAndDown.transform.localPosition = new Vector3(0,  Mathf.Clamp(m_CameraUpAndDown.transform.localPosition.y, 1f, 20f),0);
    }

    /// <summary>
    /// 设置摄像机 缩放
    /// </summary>
    /// <param name="type">0=拉近 1=拉远</param>
    public void SetCameraZoom(int type)
    {
        m_CameraContainer.Translate(Vector3.forward * 10 * Time.deltaTime * ((type == 1 ? -1 : 1)));
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z, -8f,8f));
    }

    /// <summary>
    /// 实时看着主角
    /// </summary>
    /// <param name="pos"></param>
    public void AutoLookAt(Vector3 pos)
    {
        m_CameraZoomContainer.LookAt(pos);
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 15f);

    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, 14f);

    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, 12f);
    //}
}