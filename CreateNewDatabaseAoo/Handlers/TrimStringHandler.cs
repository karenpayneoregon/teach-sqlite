using System.Data;
using Dapper;

namespace CreateNewDatabaseAoo.Handlers;

public class TrimStringHandler : SqlMapper.TypeHandler<string>
{
    public override string Parse(object value) 
        => (value as string)?.Trim();

    public override void SetValue(IDbDataParameter parameter, string value)
    {
        parameter.Value = value;
    }
}