using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("department")]
public class DepartmentEntity
{
    // id列のマッピングされる(主キー)
    [Key]
    [Column("id")]
    public int Id { get; set; }
    // name列のマッピングされる
    [Column("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 演習-12 employeeテーブルとdepartmentテーブルを結合可能にする
    /// 所属社員
    /// </summary>
    public List<EmployeeEntity>? Employees { get; set; }

    public override string ToString()
    {
        return $"部署Id={Id} , 部署名={Name}";
    }
}