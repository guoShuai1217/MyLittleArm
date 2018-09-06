/*
 *		Description : 鼠标点击  控制角色行走 , 角色转向鼠标点击的位置 
 *		
 *		              角色身上需要 CharacterController 组件 , 不用加刚体
 *
 *		CreatedBy : guoShuai 
 *
 *		DataTime : 2018.08.22
 */
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private CharacterController m_CharacterController; // 角色控制器

    [SerializeField]
    private float m_Speed = 3f; // 角色行走速度

    private Vector3 m_TargetPos; // 角色要走到的目标位置(鼠标点击位置)

    [SerializeField]
    private float m_RotationSpeed ; // 转身速度

    private Quaternion m_TargetQuaternion; //角色要旋转的角度

   
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CameraCtrl.Instance.transform.position = transform.position;
        CameraCtrl.Instance.AutoLookAt(transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.name.Equals( "Floor",System.StringComparison.CurrentCultureIgnoreCase)) //如果点击了地面
                {
                    m_TargetPos = hit.point;                   
                    m_RotationSpeed = 0f;
                }
            }
        }

  
        if (m_TargetPos != Vector3.zero)
        {
            if(Vector3.Distance(m_TargetPos,transform.position) >= 0.1f)
            {
                Vector3 dir = (m_TargetPos - transform.position).normalized;
                dir = dir * Time.deltaTime * m_Speed;
                dir.y = 0;
                // 注意 : 这样写 可以解决人物打转问题..(但是转身太快,可以用下面的代码优化)
                // transform.LookAt(new Vector3( m_TargetPos.x,transform.position.y,m_TargetPos.z));

                if (m_RotationSpeed <= 1)
                {
                    m_RotationSpeed += 5 * Time.deltaTime;
                    m_TargetQuaternion = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);                  
                }
              
                m_CharacterController.Move(dir);
            }
        }

        // 让角色始终贴着地面走 
        if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move(transform.position + new Vector3(0, -1000, 0) - transform.position);
        }

        #region 摄像机位置
        //if (Input.GetKey(KeyCode.A))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(0);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(1);
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(0);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(0);
        //}
        //else if (Input.GetKey(KeyCode.F))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(1);
        //}
        //else if (Input.GetKey(KeyCode.N))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(0);
        //}
        #endregion

        if (Input.GetKey(KeyCode.A))
        {
            CameraCtrl.Instance.SetCameraRotate(0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CameraCtrl.Instance.SetCameraRotate(1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(1);
        }
        else if (Input.GetKey(KeyCode.I))
        {
            CameraCtrl.Instance.SetCameraZoom(0);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            CameraCtrl.Instance.SetCameraZoom(1);
        }

    }

}
