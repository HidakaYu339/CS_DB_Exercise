using Microsoft.EntityFrameworkCore;

using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // employeeテーブルにアクセスするクラスのインスタンスを生成する
        var employeeAccessor = new EmployeeAccessor(context);

        // 演習-16 データの有無を確認する
        Exercise16(employeeAccessor);
    }

    /// <summary>
    /// 演習-16 データの有無を確認する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    private static void Exercise16(EmployeeAccessor employeeAccessor)
    {
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        // 入力された社員名を含む社員とその所属部署を取得する
        var results = employeeAccessor.FindByNameContainsJoinDepartment(name!);
        // 取得した結果がnullの場合は、該当する社員が存在しない旨を表示する
        if (results == null)
        {
            Console.WriteLine($"{name}さんは、存在しません。");
        }
        else
        {
            // 取得した結果をループで回して、社員名と所属部署名を表示する
            foreach (var result in results)
            {
                Console.WriteLine($"{name}さんは、{result.Department!.Name}に所属する社員です。");
            }
        }
    }
}