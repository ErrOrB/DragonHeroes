using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class GuidedBullet : Bullet {


        float tBulletX = 0.0f;
        float tBulletY = 0.0f;

        float tDirX = 0.0f;
        float tDirY = 0.0f;

        Vector2 tPlayerPos = new Vector2();
        Vector2 tBulletPos = new Vector2();

        float tActorX = 0.0f;
        float tActorY = 0.0f;

        float tSpeed = 0.0f;

        float tAngle = 0.0f;

        void Start() {
            
            tDirX = 1.0f;
            tDirY = 1.0f;

            tActorX = 0.0f;
            tActorY = 4.0f;
            
            tSpeed = 1.0f;
            tAngle = 45.0f;

            
            tBulletPos = GetPosition();
            tPlayerPos = new Vector2(0, -4);

        }

        void Update() {

            ///          탄의 좌표,           탄의 속도 벡터,  캐릭터 좌표,      탄의 속도, 선회 각도의 상한치
            // UpdateBullet(tBulletX, tBulletY, tDirX, tDirY, tActorX, tActorY, tSpeed, tAngle);

            //tActorX = tActorX + 1;
            //tActorY = tActorY - 1

            
            UpdateGuidedBullet(tBulletPos, mCurrenDir, tPlayerPos, tSpeed, tAngle);
            //Debug.Log(tBulletPos);
            //Debug.Log(tPlayerPos);
        }

        void UpdateBullet(float tBulletX, float tBulletY, float tDirX, float tDirY, 
                          float tActorX, float tActorY, float tSpeed, float tAngle)
        {

            // 탄의 원래 속도벡터를 저장
            float tVector_0X = tDirX;
            float tVector_0Y = tDirY;
            

            // actor 방향으로의 속도 벡터(tVector_1X, tVector_1Y)를 구하기: 거리구하는 공식
            float tVector_1X;
            float tVector_1Y;
            float tDistance = Mathf.Sqrt((tActorX - tBulletX) * (tActorX - tBulletX) + (tActorY - tBulletY) * (tActorY - tBulletY));
            /// public static float Sqrt(float f);
            /// Returns square root of f.


            if (0 != tDistance)
            {
                tVector_1X = (tActorX - tBulletX) / tDistance;
                tVector_1Y = (tActorY - tBulletY) / tDistance;
            }
            else
            {
                tVector_1X = 0;
                tVector_1Y = tSpeed;
            }

            // 시계방향으로 선회할 때의 상한 각도에 해당하는 속도벡터(tVector_2X, tVector_2Y)를 구하기:삼각함수 합의 공식
            float tRadian = (PI / 180) * tAngle;
            float tVector_2X = Mathf.Cos(tRadian) * tVector_0X - Mathf.Sin(tRadian) * tVector_0Y;
            float tVector_2Y = Mathf.Sin(tRadian) * tVector_0X + Mathf.Cos(tRadian) * tVector_0Y;
            
            float tDotProduct_0_1 = tVector_0X * tVector_1X + tVector_0Y * tVector_1Y;
            float tDotProduct_0_2 = tVector_0X * tVector_2X + tVector_0Y * tVector_2Y;


            if (tDotProduct_0_1 >= tDotProduct_0_2)
            {
                //선회 가능한 범위 내에 있을 경우:
                tDirX = tVector_1X;
                tDirY = tVector_1Y;
            }
            else
            {
                //선회 가능한 범위 밖에 있을 경우:

                // 반시계방향으로 선회할 때의 상한 각도에 해당하는 속도벡터(tVector_2X, tVector_2Y)를 구하기:삼각함수 합의 공식, 음의 각 관계식
                float tVector_3X = Mathf.Cos(tRadian) * tVector_0X + Mathf.Sin(tRadian) * tVector_0Y;
                float tVector_3Y = -Mathf.Sin(tRadian) * tVector_0X + Mathf.Cos(tRadian) * tVector_0Y;

                // 탄에서 actor까지의 상대위치벡터(tX, tY)를 구하기 //tActorX = tX + tBulletX, 기하벡터의 정의
                float tX = tActorX - tBulletX;
                float tY = tActorY - tBulletY;

                


                float tDotProduct_2 = tX * tVector_2X + tY * tVector_2Y;
                float tDotProduct_3 = tX * tVector_3X + tY * tVector_3Y;

                //어느 쪽으로 선회할지 결정.
                if (tDotProduct_2 >= tDotProduct_3)
                {
                    tDirX = tVector_2X;
                    tDirY = tVector_2Y;
                }
                else
                {
                    tDirX = tVector_3X;
                    tDirY = tVector_3Y;
                }
            }
            
            //update
            // 탄의 좌표(tBulletX, tBulletY)를 갱신하여 탄을 이동시킴
            tBulletX = tBulletX + tDirX * tSpeed;
            tBulletY = tBulletY + tDirY * tSpeed;
        }


        void UpdateGuidedBullet(Vector2 tBulletPos, Vector2 tBulletDir, Vector2 tPlayerPos, 
                                float tSpeed, float tAngle)
        {

            Vector2 tVector_0 = new Vector2();
            tVector_0 = tBulletDir;

            Vector2 tVector_1 = new Vector2();

            float tDistance = Mathf.Sqrt((tPlayerPos.x - tBulletPos.x) * (tPlayerPos.x - tBulletPos.x) +
                                         (tPlayerPos.y - tBulletPos.y) * (tPlayerPos.y - tBulletPos.y));

            if (0 == tDistance)
            {

                tVector_1.x = (tPlayerPos.x - tBulletPos.x) / tDistance;
                tVector_1.y = (tPlayerPos.y - tBulletPos.x) / tDistance;
            }
            else
            {

                tVector_1.x = 0;
                tVector_1.y = tSpeed;
            }

            float tRadian = (PI / 180) * tAngle;

            Vector2 tVector_2 = new Vector2();
            tVector_2.x = Mathf.Cos(tRadian) * tVector_0.x - Mathf.Sin(tRadian) * tVector_0.y;
            tVector_2.y = Mathf.Sin(tRadian) * tVector_0.x + Mathf.Cos(tRadian) * tVector_0.y;

            float tDotProduct_0_1 = tVector_0.x * tVector_1.x + tVector_0.y * tVector_1.y;
            float tDotProduct_0_2 = tVector_0.x * tVector_2.x + tVector_0.y * tVector_2.y;

            if (tDotProduct_0_1 >= tDotProduct_0_2)
            {
                //선회 가능한 범위 내에 있을 경우:
                tVector_0.x = tVector_1.x;
                tVector_0.y = tVector_1.y;
            }
            else
            {
                //선회 가능한 범위 밖에 있을 경우:

                // 반시계방향으로 선회할 때의 상한 각도에 해당하는 속도벡터(tVector_2X, tVector_2Y)를 구하기:삼각함수 합의 공식, 음의 각 관계식
                Vector2 tVector_3 = new Vector2();
                tVector_3.x = Mathf.Cos(tRadian) * tVector_0.x + Mathf.Sin(tRadian) * tVector_0.y;
                tVector_3.y = -Mathf.Sin(tRadian) * tVector_0.x + Mathf.Cos(tRadian) * tVector_0.y;

                // 탄에서 actor까지의 상대위치벡터(tX, tY)를 구하기 //tActorX = tX + tBulletX, 기하벡터의 정의
                float tX = tPlayerPos.x - tBulletPos.x;
                float tY = tPlayerPos.y - tBulletPos.y;
            
                float tDotProduct_2 = tX * tVector_2.x + tY * tVector_2.y;
                float tDotProduct_3 = tX * tVector_3.x + tY * tVector_3.y;

                //어느 쪽으로 선회할지 결정.
                if (tDotProduct_2 >= tDotProduct_3)
                {
                    tBulletDir.x = tVector_2.x;
                    tBulletDir.y = tVector_2.y;
                }
                else
                {
                    tBulletDir.x = tVector_3.x;
                    tBulletDir.y = tVector_3.y;
                }
            }

            // update
            // 탄의 좌표를 갱신하여 탄을 이동시킴
            Vector2 tBulletMove = new Vector2();
            tBulletMove.x = tBulletPos.x + tBulletDir.x * tSpeed;
            tBulletMove.y = tBulletPos.y + tBulletDir.y * tSpeed;

            SetPosition(tBulletMove);
        }
    }
}