using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MyConponent
{
    public float playerCheckDistance;
    public LayerMask playerMask;
    public Vector2 direction;

    /// <summary>
    /// ������ͷ�����Ƿ������
    /// </summary>
    public bool CheckPlayer()
    {
        return Physics2D.Raycast(transform.position, direction, playerCheckDistance, playerMask);
    }
    /// <summary>
    /// ������ͷ�����Ƿ������
    /// </summary>
    public bool CheckPlayer(float distance)
    {
        return Physics2D.Raycast(transform.position, direction, distance, playerMask);
    }

    /// <summary>
    /// �༭�� ��������
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(direction * playerCheckDistance));
    }
}
