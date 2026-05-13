using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_DB_Exercise.Infrastructures.Entities;

[Table("employee")]
public class EmployeeEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }         // 従業員Id（主キー）
    [Column("name")]
    public string? Name { get; set; }   // 従業員名
    [Column("dept_id")]
    public int DeptId { get; set; }     // 部署Id（外部キー）

    public override string ToString()
    {
        return $"従業員Id:{Id} , 従業員名:{Name} , 部署Id:{DeptId}";
    }
}