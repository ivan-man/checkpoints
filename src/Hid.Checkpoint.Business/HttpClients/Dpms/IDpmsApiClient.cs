using Hid.Checkpoint.Business.HttpClients.Dpms.Dto;
using Hid.CheckPoint.Shared;

namespace Hid.Checkpoint.Business.HttpClients.Dpms;

public interface IDpmsApiClient
{
    /// <summary>
    ///     Штатное расписание. Список сотрудников текущей организации
    /// </summary>
    /// <param name="modifiedAfter">
    ///     Вернуть только записи о сотрудниках, которые были изменнены после заданной даты.
    ///     Включая указанную дату - т.е. условие вида 'больше или равно'.
    ///     Если параметр не задан - то возвращается весь список актуальных сотрудников.
    ///     Формат даты - 'YYYY-MM-DD'
    /// </param>
    /// <param name="uid">
    ///     Вернуть запись о конкртеном сотруднике по значению атрибута 'Employee:uid'.
    ///     Если указан параметр modifiedAt - параметры комбинируются по условию AND</param>
    /// <param name="cancellationToken">
    /// Токен отмены
    /// </param>
    Task<ResultList<EmployeeDto>> GetEmployeesAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Список организаций используемых в штатном расписании
    /// </summary>
    /// <param name="modifiedAfter">
    ///     Вернуть только записи о сущностях, которые были изменнены после заданной даты.
    ///     Включая указанную дату - т.е. условие вида 'больше или равно'.
    ///     Если параметр не задан - то возвращается весь список актуальных сущностей.
    ///     Формат даты - 'YYYY-MM-DD'
    /// </param>
    /// <param name="uid">
    ///     Вернуть запись о конкртеной сущносте по значению атрибута 'uid'.
    ///     Если указан параметр modifiedAt - параметры комбинируются по условию AND</param>
    /// <param name="cancellationToken">
    ///     Токен отмены
    /// </param>
    Task<ResultList<EmployeeDto>> GetOrganizationsAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Список точек доступа.
    ///     Доступ к списку точек доступа из СКУД
    /// </summary>
    /// <param name="modifiedAfter">
    ///     Вернуть только записи о сущностях, которые были изменнены после заданной даты.
    ///     Включая указанную дату - т.е. условие вида 'больше или равно'.
    ///     Если параметр не задан - то возвращается весь список актуальных сущностей.
    ///     Формат даты - 'YYYY-MM-DD'
    /// </param>
    /// <param name="uid">
    ///     Вернуть запись о конкртеной сущносте по значению атрибута 'uid'.
    ///     Если указан параметр modifiedAt - параметры комбинируются по условию AND</param>
    /// <param name="cancellationToken">
    ///     Токен отмены
    /// </param>
    Task<ResultList<EmployeeDto>> GetSubdivisionsAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Доступ к списку уровней доступа
    /// </summary>
    /// <param name="modifiedAfter">
    ///     Вернуть только записи о сущностях, которые были изменнены после заданной даты.
    ///     Включая указанную дату - т.е. условие вида 'больше или равно'.
    ///     Если параметр не задан - то возвращается весь список актуальных сущностей.
    ///     Формат даты - 'YYYY-MM-DD'
    /// </param>
    /// <param name="cancellationToken">
    ///     Токен отмены
    /// </param>
    Task<ResultList<EmployeeDto>> GetAccessLevelsAsync(
        DateTime? modifiedAfter,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Внесение изменнеий в список уровней доступа
    /// </summary>
    /// <param name="accessLevels">
    ///     Список изменяемых или добавялемых уровней доступа.
    ///     Различие между новым объектом и изменямеым объектом производится по существованию uid объекта в системе.
    ///     Т.е. если в системе есть объект с данным uid - мы его обновляем, иначе создаем
    /// </param>
    /// <param name="cancellationToken">
    ///     Токен отмены
    /// </param>
    Task<Result> EditAccessLevelListAsync(
        IEnumerable<AccessLevel> accessLevels,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Доступ к списку точек доступа из СКУД
    /// </summary>
    /// <param name="cancellationToken">
    ///     Токен отмены
    /// </param>
    Task<ResultList<EmployeeDto>> GetAccessPointsAsync(
        CancellationToken cancellationToken = default);
}
