using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class CurvedBullet : Bullet
    {
        private float mAccumulateTime = 0.25f;
        private float mRadius = 0.5f;
        
        void Start()
        {
            mCurrentSpeed = 0.3f;
            mCurrenDir = new Vector2(5, 2);
        }
        
        void Update()
        {
            BulletUpdate(-0.1f);
        }

        protected override void BulletUpdate(float dt)
        {
            mAccumulateTime += dt;
            Vector2 tVec = GetPosition();

            //tVec.x += (mCurrenDir.x * mCurrentSpeed) * dt;
            tVec.y += (mCurrenDir.y * mCurrentSpeed) * dt;

            //tVec.x += Mathf.Abs(Mathf.Cos((PI * 2) * mAccumulateTime) * mRadius) * dt;
            //tVec.y += (Mathf.Sin((PI * 2) * mAccumulateTime) * mRadius) * mCurrenDir.y * dt;

            tVec.y += Mathf.Abs(Mathf.Cos((PI * 2) * mAccumulateTime) * mRadius) * dt;
            tVec.x += (Mathf.Sin((PI * 2) * mAccumulateTime) * mRadius) * mCurrenDir.x * dt;

            SetPosition(tVec);
        }
    }
}

/// public static float Abs(float f);
/// Returns the absolute value of f.

/// public static float Cos(float f);
/// Returns the cosine of angle f in radians.

/// public static float Sin(float f);
/// float The return value between -1 and +1.