using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures;
using CS_DB_Exercise.Infrastructures.Entities; // 追加

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // EmployeeおよびDepartmentテーブルアクセスクラスを生成する
        var employeeAccessor = new EmployeeAccessor(context);
        var departmentAccessor = new DepartmentAccessor(context);

        // 演習-09 employeeテーブルに新しい社員を追加する
        Exercise09(employeeAccessor, departmentAccessor);
    }

    /// <summary>
    /// 演習-09 employeeテーブルに新しい社員を追加する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    /// <param name="departmentAccessor">Departmentテーブルアクセスクラス</param>
    static void Exercise09(EmployeeAccessor employeeAccessor, DepartmentAccessor departmentAccessor)
    {
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);

        Console.WriteLine("演習-09 employeeテーブルに新しい社員の情報を登録する");
        // 入力された部署Idが存在するか確認する
        if (departmentAccessor.FindById(deptId) == null)
        {
            Console.WriteLine($"部署Id:{deptId}は存在しないため、社員登録できません");
            return;
        }

        // 登録する社員エンティティを生成する
        var newEployee = new EmployeeEntity
        {
            Name = name,
            DeptId = deptId
        };

        // employeeテーブルに新しい社員を追加する
        employeeAccessor.Create(newEployee);
        Console.WriteLine($"社員名:{name}、部署Id:{deptId}の社員を登録しました");
    }
}
