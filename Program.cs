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
        // var departmentAccessor = new DepartmentAccessor(context);

        // 演習-10 employeeテーブルの社員名を変更する
        Exercise10(employeeAccessor);
    }

    /// <summary>
    /// 演習-10 employeeテーブルの社員名を変更する
    /// </summary>
    /// <param name="employeeAccessor">Employeeテーブルアクセスクラス</param>
    /// <returns></returns>
    private static void Exercise10(EmployeeAccessor employeeAccessor)
    {
        Console.Write("社員Idを入力してください->");
        var empId = int.Parse(Console.ReadLine()!);
        Console.Write("社員名を入力してください->");
        var name = Console.ReadLine();

        Console.WriteLine("演習-10 指定された社員Idの社員名を変更する");
        // 変更後の社員情報を作成する
        var updateEployee = new EmployeeEntity
        {
            Id = empId,
            Name = name,
        };

        // 社員情報を更新する
        var result = employeeAccessor.UpdateById(updateEployee);
        // 更新結果がnullの場合は、指定された社員Idの社員が存在しないため、変更できなかったことを表示する
        if (result == null)
        {
            Console.WriteLine($"社員Id:{empId}の社員は存在しないため変更できませんでした");
            return;
        }
        Console.WriteLine($"社員名:を{result.Name}に変更しました");
    }
}
