using CS_DB_Exercise.Infrastructures.Entities;
using CS_DB_Exercise.Infrastructures;

namespace CS_DB_Exercise.Infrastructure.Queries;

public class DepartementAccessor
{
    //  アプリケーション用DbContext
    private readonly AppDbContext _context;

    public DepartementAccessor(AppDbContext context)
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
    /// 指定した部署Idの部署を取得する
    /// </summary>
    /// <param name="departmentId">部署Id(主キー)</param>
    public DepartmentEntity? FindById(int departmentId)
    {
        // Find()メソッドを使用して、指定した部署Idの部署を取得する
        var department = _context.Departments.Find(departmentId);
        return department;
    }
}