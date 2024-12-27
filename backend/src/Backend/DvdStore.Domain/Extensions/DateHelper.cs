using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DvdStore.Domain.Extensions;

public static class DateHelper
{
    public static string ToFormattedDateTime(object value)
    {
        if (value == null || value == DBNull.Value)
        {
            return string.Empty;
        }

        if (DateTime.TryParse(value.ToString(), out DateTime date))
        {
            return date.ToString("dd/MM/yyyy HH:mm:ss", new System.Globalization.CultureInfo("pt-BR"));
        }

        return string.Empty;
    }
}
