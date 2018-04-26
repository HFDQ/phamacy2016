系统仓储实现
//生成迁移代码
Add-Migration AddCity
//生成迁移SQL脚本 但不执行
Update-Database -Script -SourceMigration: $InitialDatabase -TargetMigration: AddCity
//执行迁移脚本到数据库
Update-Database -Verbose

