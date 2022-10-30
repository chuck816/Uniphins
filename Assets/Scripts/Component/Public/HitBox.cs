using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MyConponent
{
    private Collider2D obj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision;       
    }
    /// <summary>
    /// ����hitbox������⵽������ı�ǩ��Tag��ǩ�ȽϵĲ���ֵ
    /// </summary>
    /// <param name="Tag"></param>
    /// <returns></returns>
    public bool IsObjHurt(string Tag)
    {
        if (obj != null)
        {
            return obj.CompareTag(Tag);
        }
        else
        {
            return false;
        }
    }
}
