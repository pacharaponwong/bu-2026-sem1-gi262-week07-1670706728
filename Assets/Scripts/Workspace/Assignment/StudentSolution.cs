using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            // Your code here ...
            // ...
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
               
            }
            if (index == -1)
            {
                UnityEngine.Debug.Log("find not found");
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            // Your code here ...
            // ...
            for (int i =0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1 && col != -1)
                {
                    break;
                }
            }

            return new[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            int left = 0;
            int right = array.Length - 1;
            // Your code here ...
            // ...
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else if (array[mid] > target)
                {
                    right = mid - 1;
                }
            }
            return index;
        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i; // บันทึกตำแหน่งแรกที่เจอ
                    }
                    last = i; // อัปเดตตำแหน่งสุดท้ายไปเรื่อยๆ
                }
            }

            // หากไม่พบค่าเลย ให้คืนค่าอาร์เรย์ที่มีเพียง -1 ตามที่ Test Case ระบุ
            if (first == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            int maxLess = -1;
            bool found = false;

            // วนลูปหาค่าที่น้อยกว่า target แต่มีค่ามากที่สุด
            // (ครอบคลุมกรณีที่อาร์เรย์อาจไม่ได้เรียงลำดับมาตาม Test Case)
            foreach (int num in array)
            {
                if (num < target)
                {
                    if (!found || num > maxLess)
                    {
                        maxLess = num;
                        found = true;
                    }
                }
            }

            return maxLess;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            List<int> result = new List<int>();

            foreach (int num in array)
            {
                // ตรวจสอบว่าค่าอยู่ในช่วง [min, max] รวม min และ max ด้วย
                if (num >= min && num <= max)
                {
                    result.Add(num);
                }
            }

            // ถ้าไม่พบค่าเลย คืนค่าเป็นอาร์เรย์ว่าง (Empty Array) ตาม Test Case[cite: 1]
            return result.ToArray();
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            // สร้างอาร์เรย์ใหม่เพื่อไม่ให้กระทบค่าเดิม แล้วทำการเรียงลำดับจากน้อยไปมาก
            int[] sortedHPs = (int[])enemyHPs.Clone();
            Array.Sort(sortedHPs);

            List<int> targets = new List<int>();
            int currentMana = mana;

            // เลือกโจมตีศัตรูที่มี HP น้อยที่สุดก่อน เพื่อให้กำจัดศัตรูได้จำนวนมากที่สุด
            foreach (int hp in sortedHPs)
            {
                if (currentMana >= hp)
                {
                    targets.Add(hp);
                    currentMana -= hp; // หักมานาที่ใช้ไป
                }
                else
                {
                    // ถ้ามานาไม่พอแล้วให้หยุดการตรวจสอบ
                    break;
                }
            }

            return targets.ToArray();
        }

        #endregion
    }
}
