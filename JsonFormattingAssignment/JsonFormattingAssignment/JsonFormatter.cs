using System.Collections;
using System.Reflection;

namespace JsonFormattingAssignment
{
    public static class JsonFormatter
    {
        private static readonly string SkipSentinel = "\0SKIP\0";

        public static string Convert(object obj, bool isNullableContext = false)
        {
            // ── Null ──────────────────────────────────────────────────────────────
            if (obj == null)
            {
                if (isNullableContext)
                    return SkipSentinel;

                return "null";
            }

            Type type = obj.GetType();

            // ── string ────────────────────────────────────────────────────────────
            if (obj is string s)
            {
                if (string.IsNullOrEmpty(s))
                    return "\"\"";

                var sb = new System.Text.StringBuilder(s.Length);
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
                                sb.Append($"\\u{(int)c:X4}");
                            else
                                sb.Append(c);
                            break;
                    }
                }
                return "\"" + sb.ToString() + "\"";
            }

            // ── char ──────────────────────────────────────────────────────────────
            if (obj is char ch)
                return "\"" + ch.ToString() + "\"";

            // ── bool ──────────────────────────────────────────────────────────────
            if (obj is bool b)
                return b ? "true" : "false";

            // ── DateTime ──────────────────────────────────────────────────────────
            if (obj is DateTime dt)
                return "\"" + dt.ToString("M/d/yyyy h:mm:ss tt") + "\"";

            // ── Numeric ───────────────────────────────────────────────────────────
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return System.Convert.ToString(obj, System.Globalization.CultureInfo.InvariantCulture);
            }

            // ── IEnumerable (Array / List<T>) ─────────────────────────────────────
            if (obj is IEnumerable enumerable)
            {
                var items = new List<string>();
                foreach (object item in enumerable)
                {
                    items.Add(Convert(item, isNullableContext: false));
                }
                return "[" + string.Join(",", items) + "]";
            }

            // ── Complex Object ────────────────────────────────────────────────────
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var parts = new List<string>();

            foreach (PropertyInfo prop in props)
            {
                // Skip indexers
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                // Detect Nullable<T>
                bool isNullable = prop.PropertyType.IsGenericType &&
                                  prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);

                object rawValue = prop.GetValue(obj);

                string serialized = Convert(rawValue, isNullableContext: isNullable);

                // Nullable<T> with no value → skip property
                if (serialized == SkipSentinel)
                    continue;

                parts.Add("\"" + prop.Name + "\":" + serialized);
            }

            return "{" + string.Join(",", parts) + "}";
        }
    }
}