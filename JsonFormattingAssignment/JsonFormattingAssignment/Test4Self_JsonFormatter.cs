using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Assignment_1
{
    public class Test4Self_JsonFormatter
    {
        public static string Convert(object item)

        {

            if (item == null)

                return "null";

            return SerializeValue(item);

        }

        private static string SerializeValue(object value)

        {

            if (value == null)

                return "null";

            Type type = value.GetType();

            // --- Primitives ---

            if (type == typeof(bool))

                return (bool)value ? "true" : "false";

            if (type == typeof(int))

                return value.ToString();

            if (type == typeof(double))

                return ((double)value).ToString("G", System.Globalization.CultureInfo.InvariantCulture);

            if (type == typeof(decimal))

                return ((decimal)value).ToString("G", System.Globalization.CultureInfo.InvariantCulture);

            if (type == typeof(char))

                return $"\"{EscapeString(value.ToString())}\"";

            if (type == typeof(string))

                return $"\"{EscapeString((string)value)}\"";

            if (type == typeof(DateTime))

                return $"\"{((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss")}\"";

            // --- Array ---

            if (type.IsArray)

                return SerializeEnumerable((IEnumerable)value);

            // --- List<T> ---

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))

                return SerializeEnumerable((IEnumerable)value);

            // --- Complex object (recurse into properties) ---

            return SerializeObject(value);

        }

        private static string SerializeEnumerable(IEnumerable collection)

        {

            var sb = new StringBuilder();

            sb.Append("[");

            bool first = true;

            foreach (var item in collection)

            {

                if (!first)

                    sb.Append(",");

                sb.Append(SerializeValue(item));

                first = false;

            }

            sb.Append("]");

            return sb.ToString();

        }

        private static string SerializeObject(object obj)

        {

            if (obj == null)

                return "null";

            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var sb = new StringBuilder();

            sb.Append("{");

            bool first = true;

            foreach (var prop in properties)

            {

                // Only include readable properties

                if (!prop.CanRead)

                    continue;

                object propValue = prop.GetValue(obj);

                if (!first)

                    sb.Append(",");

                // Property name as JSON key

                sb.Append($"\"{prop.Name}\":");

                // Recursively serialize the property value

                sb.Append(SerializeValue(propValue));

                first = false;

            }

            sb.Append("}");

            return sb.ToString();

        }

        private static string EscapeString(string s)

        {

            if (s == null)

                return string.Empty;

            var sb = new StringBuilder(s.Length);

            foreach (char c in s)

            {

                switch (c)

                {

                    case '"': sb.Append("\\\""); break;

                    case '\\': sb.Append("\\\\"); break;

                    case '\n': sb.Append("\\n"); break;

                    case '\r': sb.Append("\\r"); break;

                    case '\t': sb.Append("\\t"); break;

                    case '\b': sb.Append("\\b"); break;

                    case '\f': sb.Append("\\f"); break;

                    default:

                        if (c < 0x20)

                            sb.Append($"\\u{(int)c:x4}");

                        else

                            sb.Append(c);

                        break;

                }

            }

            return sb.ToString();

        }

    }
}
