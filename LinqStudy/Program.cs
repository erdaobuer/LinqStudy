using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqStudy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ///sss/vvv
            var ssd = string.Concat(new object[4]
              {
                (object) "/",
                (object)"sss",
                (object) "/",
                (object) "vvv"
              });

            //Fun1();
            //Fun2();
            //Fun3();
            Fun4();
        }

        #region Linq查询数组

        /// <summary>
        /// Linq查询数组
        /// </summary>
        public static void Fun1()
        {
            string[] str = new string[] { "中国", "美国", "德国", "印度", "希腊", "西班牙", };

            var result = from s in str
                         where s.IndexOf("国") > 0
                         select s;
            foreach (var item in result)
            {
                Console.WriteLine("{0,1}", item + "。。。" + item.IndexOf("国"));
            }
        }

        #endregion Linq查询数组

        #region Linq查询List

        /// <summary>
        /// Linq查询List
        /// </summary>
        public static void Fun2()
        {
            List<Student> students = new List<Student> {
                                     new Student{ Name="欧阳晓晓",Age=35,Tel="138****7854,187****5736"},
                                     new Student{ Name="上官飘飘",Age=23,Tel="152****5387,130****5542"},
                                     new Student{ Name="欧阳晓晓",Age=14,Tel="132****0857,133****8801"},
                                     new Student{ Name="欧阳晓晓",Age=19,Tel="152****5490,187****1479"}
            };

            var result = from Student s in students
                         where s.Age >= 20
                         select s;
            foreach (var item in result)
            {
                Console.WriteLine("姓名:{0},年龄:{1},电话:{2}", item.Name, item.Age, item.Tel);
            }
        }

        #endregion Linq查询List

        #region 复合from子句

        /// <summary>
        /// 复合from子句
        /// </summary>
        public static void Fun3()
        {
            List<StudentExt> students = new List<StudentExt> {
                                        new StudentExt{ Name="欧阳晓晓",Age=35,TelTable=new List<string>{"138****7854","187****5736"}},
                                        new StudentExt{ Name="上官飘飘",Age=23,TelTable=new List<string>{"152****5387","130****5542"}},
                                        new StudentExt{ Name="欧阳晓晓",Age=14,TelTable=new List<string>{"132****0857","133****8801"}},
                                        new StudentExt{ Name="欧阳晓晓",Age=19,TelTable=new List<string>{"152****5490","187****1479"} }
            };

            var result = from StudentExt s in students
                         from tel in s.TelTable
                         where tel.IndexOf("152****5387") > -1
                         select s;
            if (result == null) return;
            {
            }
            foreach (var item in result)
            {
                Console.WriteLine("姓名:{0},年龄:{1}", item.Name, item.Age);
                foreach (var tel in item.TelTable)
                {
                    Console.WriteLine("     电话:{0}", tel);
                }
            }
        }

        #endregion 复合from子句

        #region 多个from子句

        /// <summary>
        /// 多个from子句
        /// </summary>
        public static void Fun4()
        {
            List<Student> clist = new List<Student> {
                                                   new Student{ Name="欧阳晓晓", Age=35, Tel ="1330708****"},
                                                   new Student{ Name="上官飘飘", Age=17, Tel ="1592842****"},
                                                   new Student{ Name="诸葛菲菲", Age=23, Tel ="1380524****"}
                                                   };
            List<Student> clist2 = new List<Student> {
                                                   new Student{ Name="令狐冲", Age=25, Tel ="1330708****"},
                                                   new Student{ Name="东方不败", Age=35, Tel ="1592842****"},
                                                   new Student{ Name="任盈盈", Age=23, Tel ="1380524****"}
                                                   };

            //在clist中查找Age>20的客户
            //在clist2中查找Age<30的客户
            var result = from stu in clist
                         where stu.Age > 20
                         from stu2 in clist2
                         where (stu2.Age < 30 && stu2.Name.Contains("方"))
                         select new { stu, stu2 };
            foreach (var s in result)
            {
                Console.WriteLine("{0} {1}", s.stu.Name, s.stu2.Name);
            }
        }

        #endregion 多个from子句
    }
}