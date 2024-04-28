using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2.Classes;
public class SqlStatements
{
    public static string GetPartialContact =>
        """
        SELECT ContactId,
               FirstName,
               LastName,
               ContactTypeIdentifier
        FROM Contacts
        WHERE ContactId = @ContactId
        """;
}
