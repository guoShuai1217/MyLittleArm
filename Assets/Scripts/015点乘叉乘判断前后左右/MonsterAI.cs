/*
 *            Description : 点乘叉乘判断前后左右 , 挂载在小怪 
 *            
 *            点乘: a * b * cos<a,b> 是一个标量 , 没有方向 [一全正,二正弦,三切,四余弦]
 *            
 *            叉乘: a * b * sin<a,b> 是一个矢量 , 有方向的 , 满足右手定则 , 叉乘结果垂直于 a , b 两个向量
 *
 *            CreatedBy : guoShuai
 *
 *            DataTime : 2018.09.29
 */

using UnityEngine;
public class MonsterAI : MonoBehaviour
{
    /// <summary>
    /// 点乘判断前后
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Dir ForwardOrBackByDot(Transform target)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, dir);
        if (dot > 0)
            return Dir.Forward;
        else
            return Dir.Back;
    }


    /// <summary>
    /// 点乘判断左右
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Dir LeftOrRightByDot(Transform target)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.right, dir);
        if (dot > 0)
            return Dir.Right;
        else
            return Dir.Left;
    }


    /// <summary>
    /// 叉乘判断前后
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Dir ForwardOrBackByCross(Transform target)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Vector3 cross = Vector3.Cross(transform.right, dir);
        if (cross.y > 0)
            return Dir.Forward;
        else
            return Dir.Back;
    }


    /// <summary>
    /// 叉乘判断左右
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public Dir LeftOrRightByCross(Transform target)
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Vector3 cross = Vector3.Cross(transform.forward, dir);
        if (cross.y > 0)
            return Dir.Left;
        else
            return Dir.Right;
    }
}
public enum Dir
{
    Forward,
    Back,
    Left,
    Right
}
