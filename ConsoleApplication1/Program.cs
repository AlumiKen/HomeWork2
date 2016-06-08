using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                #region 讀資料起手
                //foreach (var item in db.Course)
                //{
                //    Console.WriteLine(item.Title);
                //}
                //linq寫法
                //db.Course.AsEnumerable().Select(i => i.Title).ToList().ForEach(b => Console.WriteLine(b));

                //var newcourse = new Course()
                //{
                //    CourseID = 0,
                //    Credits = 1,
                //    CreatedOn = DateTime.Now,
                //    ModifiedOn = DateTime.Now,
                //    DepartmentID = 2,
                //    Title = "ken add"
                //};

                //db.Course.Add(newcourse);

                //db.Database.Log = (msg) => { Console.WriteLine(msg); };
                #endregion

                #region StoreGeneratedPattern練習
                //var c = db.Course.Find(2);
                //c.Credits += 1;
                //c.CreatedOn = new DateTime(2000, 1, 1);
                //c.ModifiedOn = new DateTime(2000, 1, 1);
                //db.SaveChanges();
                #endregion

                #region 狀態偵測
                //c.Credits += 1;
                //Console.WriteLine(db.Entry(c).State);
                //db.Course.Add(c);
                //db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                //Console.WriteLine(db.Entry(c).State);

                //var c = db.Course.Find(9);
                //Console.WriteLine(db.Entry(c).State);
                //db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();
                //Console.WriteLine(db.Entry(c).State);
                #endregion

                #region 離線模式
                //var c = new Course()
                //{
                //    CourseID = 0,
                //    Credits = 1,
                //    CreatedOn = DateTime.Now,
                //    ModifiedOn = DateTime.Now,
                //    DepartmentID = 2,
                //    Title = "ken add"
                //};

                //using (var db1 = new ContosoUniversityEntities())
                //{
                //    //db1.Course.Add(c);
                //    //db1.Course.Attach(c);
                //    //db1.Entry(c).State = System.Data.Entity.EntityState.Added;
                //    //var c = db1.Course.Find(2);
                //    //db1.Course.Remove(c);

                //    //db1.Entry(new Course { CourseID = 11 }).State = System.Data.Entity.EntityState.Deleted;

                //    //db1.Database.SqlQuery<Course>("DELETE FROM dbo.Course WHERE CourseID = @p1", 2);

                //    Console.WriteLine(c.Credits);
                //    c = db1.Course.Find(1);
                //    c.Credits += 10;
                //    Console.WriteLine(c.Credits);
                //    Console.WriteLine(db1.Entry(c).State);
                //}

                //using (var db2 = new ContosoUniversityEntities())
                //{
                //    //db2.ChangeTracker.DetectChanges();

                //    db2.Course.Attach(c);
                //    db2.Entry(c).State = System.Data.Entity.EntityState.Added;
                //    db2.SaveChanges();
                //}
                #endregion

                #region 並行模式 要開兩個.exe
                //var c = db.Department.Find(2);
                //c.Name += "ken add";
                //Console.ReadLine();
                //db.SaveChanges();
                //Console.ReadLine();
                #endregion

                #region 新刪修改用sp, table的預存程序對應要加入sp
                //db.Database.Log = Console.WriteLine;
                //var c = db.Department.Find(2);
                //db.Entry(c).State = System.Data.Entity.EntityState.Added;
                //db.SaveChanges();
                #endregion

                #region 列舉轉換與查詢
                db.Database.Log = Console.WriteLine;

                //var c = db.Course.Find(11);
                //c.Credits = CourseCredits.高級;
                //db.SaveChanges();

                db.Course.Where(p => p.Credits.HasFlag(CourseCredits.初級 | CourseCredits.高級)).ToList().ForEach(p => Console.WriteLine(p.Title + "\t" + p.Credits));
                #endregion
            }
        }
    }
}
