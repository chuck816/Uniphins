using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : Entity
{
    //���
    PlayerInputMgr input;
    Rigidbody2D rb;
    BoxCollider2D boxColl;
    CircleCollider2D cirColl;
    public PlayerInputMgr Input { get => input; private set => input = value; }
    public BoxCollider2D BoxColl { get => boxColl; set => boxColl = value; }
    public CircleCollider2D CirColl { get => cirColl; set => cirColl = value; }
    public Rigidbody2D Rb { get => rb; set => rb = value; }


    //��������������״̬
    public bool isMove=>InRange();
    public bool isWall;
    public bool isIdle => AtPoint();
    public bool isHit;
    public bool isReact;
    public bool isDead;
    public bool isOutRange => OutOfRange();
    
    public bool isAttack;
    public bool isAttackReady;

    public int moveDir;
    //������
    private void Awake()
    {
        isAttack = false;
        Rb = GetComponent<Rigidbody2D>();
        input = GetComponentInChildren<PlayerInputMgr>();
        BoxColl = GetComponent<BoxCollider2D>();
        CirColl = GetComponent<CircleCollider2D>();
        //�Զ������
        ComponentInitialize();
    }

    #region �����ٶ�
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        Rb.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        Rb.velocity = new Vector3(velocityX, Rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        Rb.velocity = new Vector3(Rb.velocity.x, velocityY);
    }
    #endregion

    #region ��������
    public void SetForce(Vector2 force)
    {
        Rb.AddForce(force);
    }
    public void SetForceX(float forceX)
    {
        Vector2 forceV = new Vector2(forceX, 0f);
        rb.AddForce(forceV);
    }
    public void SetForceY(float forceY)
    {
        Vector2 forceV = new Vector2(0f, forceY);
        rb.AddForce(forceV);
    }
    #endregion

    #region �����¼�����
    public void Move()
    { 
        EnemyMove move= GetComponentInChildren<EnemyMove>();
        move.MoveBySpeed();
    }
    public void SetHitFalse()
    {
        isHit = false;
    }
    public void SetHitTrue()
    {
        isHit = true;
    }
    #endregion

    #region �����������
    public bool OutOfRange()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
       return !patrol.PatrolCheckXIn();
    }
    public bool InRange()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
        return patrol.PatrolCheckXIn();
    }
    public bool AtPoint()
    {
        Patrol patrol = GetComponentInChildren<Patrol>();
        return patrol.PatrolAtLPoint() || patrol.PatrolAtRPoint();
    }
   

    #endregion
}
