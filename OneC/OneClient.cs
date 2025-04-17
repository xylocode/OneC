using V83;

namespace OneC
{
    public class OneClient
    {
        private readonly COMConnector connector;
        private readonly dynamic refer;

        public OneClient(string connectionString)
        {
            connector = new COMConnector
            {
                PoolCapacity = 10,
                PoolTimeout = 60,
                MaxConnections = 2,
            };
            refer = connector.Connect(connectionString);
        }

        public IEnumerable<Employee> GetStaff()
        {
            dynamic query = refer.NewObject("Запрос");
            query.Текст = @"
SELECT
ПРЕДСТАВЛЕНИЕ(УникальныйИдентификатор(Ссылка)) Id,
ПРЕДСТАВЛЕНИЕ(УникальныйИдентификатор(ГоловнаяОрганизация.Ссылка)) OrganizationId,
ГоловнаяОрганизация.ОГРН Organization,
Код Code,
ФизическоеЛицо.ФИО Name
FROM Справочник.Сотрудники
WHERE ПометкаУдаления = FALSE AND ВАрхиве = FALSE
ORDER BY Organization ASC, Code ASC
";
            //query.УстановитьПараметр("Организация", org);
            dynamic selection = query.Выполнить().Выгрузить();

            foreach (dynamic item in selection)
            {
                yield return new Employee
                {
                    Id = Guid.Parse(item.Id),
                    OrganizationId = Guid.Parse(item.OrganizationId),
                    Organization = item.Organization,
                    Code = item.Code,
                    Name = item.Name,
                };
            }
        }
    }
}
