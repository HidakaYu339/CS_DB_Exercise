using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures;

namespace CS_DB_Exercise.Infrastructures.Accessors;
/// <summary>
/// departmentテーブルにアクセスするクラス
/// </summary>
public class DepartmentAccessor
{
    // DbContextのインスタンスを保持するフィールド
    private readonly AppDbContext _context;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">演習用DbContext</param>
    public DepartmentAccessor(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// すべての部署を取得する
    /// </summary>
    public List<DepartmentEntity> FindAll()
    {
        // ToList()メソッドを使用して、すべての部署を取得する
        var departments = _context.Departments.ToList();
        return departments;
    }

    /// <summary>
    /// 演習-06 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="id">部署Id(主キー)</param>
    public DepartmentEntity? FindById(int id)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Departments.Find(id);
        return department;
    }

    /// <summary>
    /// 演習-06 (別解) departmentテーブルから主キー値で部署を取得する
    /// </summary>
    /// <returns>取得結果</returns>
    // public DepartmentEntity? FindById(int id)
    // {
    //     var department = _context.Departments
    //         .Where(d => d.Id == id)
    //         .SingleOrDefault();
    //     return department;
    // }
}