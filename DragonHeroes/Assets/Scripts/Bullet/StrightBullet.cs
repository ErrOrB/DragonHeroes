using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class StrightBullet : Bullet
    {

        // Use this for initialization
        void Start()
        {
            mCurrentSpeed = 1.0f;
            mCurrenDir = new Vector2(0, 1);
        }

        // Update is called once per frame
        void Update()
        {
            BulletUpdate(-0.1f);

        }

        protected override void BulletUpdate(float dt)
        {
            Vector2 tPos = this.GetPosition();
            //Debug.Log(tPos);

            tPos.x += mCurrenDir.x * (mCurrentSpeed * dt);
            tPos.y += mCurrenDir.y * (mCurrentSpeed * dt);
            this.SetPosition(tPos);
            //Debug.Log(tPos);
        }

    }
}