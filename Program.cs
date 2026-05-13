using CS_DB_Exercise.Infrastructures.Accessors;
using CS_DB_Exercise.Infrastructures;

namespace CS_DB_Exercise;

class Program
{
    static void Main(string[] args)
    {
        // 演習用DbContextを生成する
        var context = new AppDbContext();

        // DepartmentAccessorを生成する
        //var departmentAccessor = new DepartmentAccessor(context);

        // 演習-05 すべての部署を取得する
        // Exercise05(departmentAccessor);

        // 演習-06 departmentテーブルから主キー値で部署を取得する
        // Departmentテーブルアクセスクラスを生成する
        // Exercise06(departmentAccessor);

        // Employeeテーブルアクセスクラスを生成する
        var employeeAccessor = new EmployeeAccessor(context);
        // 演習-07 employeeテーブルから部署Idで該当社員を取得する
        // Exercise07(employeeAccessor);
        // 演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する
        Exercise08(employeeAccessor);
    }

    /// <summary>
    /// 演習-05 すべての部署を取得する
    /// </summary>
    /// <param name="departmentAccessor">DepartmentAccessorのインスタンス</param>
    static void Exercise05(DepartmentAccessor departmentAccessor)
    {
        // FindAll()メソッドを使用して、すべての部署を取得する
        var departments = departmentAccessor.FindAll();
        // 取得した部署をコンソールに表示する
        foreach (var department in departments)
        {
            Console.WriteLine(department);
        }
    }

    /// <summary>
    /// 演習-06 departmentテーブルから主キー値で部署を取得する
    /// </summary>
    /// <param name="accessor">DepartmentAccessorのインスタンス</param>
    static void Exercise06(DepartmentAccessor accessor)
    {
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        var department = accessor.FindById(deptId);

        Console.WriteLine("演習-06 departmentテーブルから主キー値で部署を取得する");
        if (department != null)
        {
            Console.WriteLine(department);
        }
        else
        {
            Console.WriteLine($"部署Id:{deptId}の部署は存在しません");
        }
        return;
    }

    /// <summary>
    /// 演習-07 employeeテーブルから部署Idで該当社員を取得する
    /// </summary>
    /// <param name="accessor">EmployeeAccessorのインスタンス</param>
    static void Exercise07(EmployeeAccessor accessor)
    {
        Console.Write("部署Idを入力してください->");
        var deptId = int.Parse(Console.ReadLine()!);
        var employees = accessor.FindByDeptId(deptId);

        Console.WriteLine("演習-07 employeeテーブルから部署Idで該当社員を取得する");
        if (employees != null)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine($"部署Id:{deptId}の社員は存在しません");
        }
        return;
    }

    /// <summary>
    /// 演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する
    /// </summary>
    /// <param name="accessor">EmployeeAccessorのインスタンス</param>
    static void Exercise08(EmployeeAccessor accessor)
    {
        Console.Write("キーワードを入力してください->");
        var keyword = Console.ReadLine()!;
        var employees = accessor.FindByContainsName(keyword);

        Console.WriteLine("演習-08 employeeテーブルから社員名の部分一致検索で該当社員を取得する");
        if (employees != null)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        else
        {
            Console.WriteLine($"キーワード:{keyword}が含まれる社員は存在しません");
        }
        return;
    }
}
