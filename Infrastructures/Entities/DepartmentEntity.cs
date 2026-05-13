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

    public override string ToString()
    {
        return $"id = {Id} , name = {Name}";
    }
}