using System.Data;
using Dapper;

namespace CreateNewDatabaseApp.Handlers;

public class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly date) 
        => parameter.Value = date.ToString("yyyy-MM-dd");

    public override DateOnly Parse(object value)
        => DateOnly.FromDateTime((DateTime)value);
}