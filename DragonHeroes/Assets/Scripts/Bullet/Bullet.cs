using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    /// Class:  Bullet
    ///
    /// Summary: 총알 부모 클래스
    ///
    /// Author: Master
    ///
    /// Date:   2017-09-19

    public class Bullet : MonoBehaviour
    {
        protected readonly float PI = 3.14f;

        protected float mSpeed { get; set; }
        protected float mCurrentSpeed { get; set; }
        protected Vector2 mCurrenDir { get; set; }
        


        protected Vector2 GetPosition()
        { return this.GetComponent<Transform>().transform.position; }

        protected void SetPosition(Vector2 tPos)
        { this.GetComponent<Transform>().transform.position = tPos; }

        protected virtual void BulletUpdate(float dt)
        { }
    }
}