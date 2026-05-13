using CS_DB_Exercise.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CS_DB_Exercise.Infrastructures;

public class AppDbContext : DbContext
{
    /// <summary>
    /// departmentテーブルにマッピングされるDbSetプロパティ 
    /// </summary>
    public DbSet<DepartmentEntity> Departments { get; set; } = null!;

    /// <summary>
    /// employeeテーブルにマッピングされるDbSetプロパティ 
    /// </summary>
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;

    /// <summary>
    /// DbContextの構成処理をする
    /// データベース接続情報の設定や、SQLログ出力の有効化する
    /// </summary>
    /// <param name="optionsBuilder">
    /// DbContextの動作設定を構築するためのオプションビルダーオブジェクト
    /// 接続先データベースやログ設定などを定義
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 接続文字列（サーバー名、DB名、ユーザー名、パスワード）
        string connectionString =
            "Host=localhost;Database=cs_db_exercise;Username=postgres;Password=training;";
        optionsBuilder
        // PostgreSQLデータベースに接続する設定
        // - connectionString：接続文字列（サーバー名、DB名、ユーザー名、パスワード）
        .UseNpgsql(connectionString)
        // 実行されたSQLをコンソールに表示する
        // - SQL文が目に見えるので「どんなSQLが発行されているか」が分かる
        // - デバッグや学習に非常に便利
        .LogTo(Console.WriteLine, LogLevel.Information)
        // パラメーターの値もログに表示する
        // - SQLに渡された値（例: "商品名 = '鉛筆'"）も確認できる
        // - デバッグ時は便利だが、個人情報などを扱う本番環境では使わない
        .EnableSensitiveDataLogging();
    }
}