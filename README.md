# CardPay3

Приложение по обмену данными по зарплатному проекту.

Программа предназначена для создания файлов обмена данными в зарплатных проектах ПАО "МЕТКОМБАНК".

## Запуск примера

После клонирования или загрузки образца вы сможете сразу запустить его, используя базу данных в памяти.

Если вы хотите использовать образец с постоянной базой данных, вам нужно будет выполнить миграцию Entity Framework Core, прежде чем вы сможете запустить приложение, и обновить метод `ConfigureServices` в `Startup.cs` (см. ниже).

### Настройка образца для использования SQL Server

1. Обновите метод `Startup.cs` `ConfigureDevelopmentServices` следующим образом:

```
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // use in-memory database
            //ConfigureInMemoryDatabases(services);

            // use real ms database
            ConfigureMsSqlDatabases(services);

            ConfigureServices(services);

        }
```
2. Убедитесь, что ваши строки подключения в `appsettings.json` указывают на локальный экземпляр SQL Server.

3. Откройте командную строку в папке Web и выполните следующие команды:

```
Update-Database -Context EmployeContext -Project Infrastructure -StartupProject WebApplication
Update-Database -Context AppIdentityDbContext -Project Infrastructure -StartupProject WebApplication
```

Эти команды создадут две отдельные базы данных: одну для данных каталога магазина и информации о корзине покупок, а другую для учетных данных пользователя и идентификационных данных приложения.

4. Запустите приложение.

При первом запуске приложения оно заполнит обе базы данных такими данными, что вы должны увидеть продукты в магазине, и вы сможете войти в систему, используя учетную запись demouser@microsoft.com.

**Примечание.** Если вам нужно создать миграции, вы можете использовать эти команды:

```
Add-Migration -Name IdentityMigration -Context AppIdentityDbContext -Project Infrastructure -StartupProject WebApplication
Add-Migration -Name EmployeMigration -Context EmployeContext -Project Infrastructure -StartupProject WebApplication
```