using System.Collections;
using System.Reflection;

namespace JsonFormattingAssignment
{
    public static class JsonFormatter
    {
        public static string Convert(object obj)
        {
            return SerializeValue(obj, isNullableContext: false);
        }

        // Sentinel returned when a Nullable<T> property has no value → caller skips the property
        private static readonly string SkipSentinel = "\0SKIP\0";

        private static string SerializeValue(object value, bool isNullableContext = false)
        {
            // ── Null ─────────────────────────────────────────────────────────────
            if (value == null)
            {
                // Nullable<T> property with no value → skip it from output entirely
                if (isNullableContext)
                    return SkipSentinel;

                return "null";
            }

            Type type = value.GetType();

            // ── string ───────────────────────────────────────────────────────────
            if (value is string s)
                return "\"" + EscapeString(s) + "\"";

            // ── char ─────────────────────────────────────────────────────────────
            if (value is char ch)
                return "\"" + EscapeString(ch.ToString()) + "\"";

            // ── bool ─────────────────────────────────────────────────────────────
            if (value is bool b)
                return b ? "true" : "false";

            // ── DateTime  →  "M/d/yyyy h:mm:ss tt"  e.g. "10/3/2022 9:09:09 AM" ──
            if (value is DateTime dt)
                return "\"" + dt.ToString("M/d/yyyy h:mm:ss tt") + "\"";

            // ── Numeric primitives ───────────────────────────────────────────────
            if (IsNumericType(type))
                return System.Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture);

            // ── Arrays / List<T>  (IEnumerable, but string is already handled) ──
            if (value is IEnumerable enumerable)
                return SerializeEnumerable(enumerable);

            // ── Complex object → recurse through properties ───────────────────
            return SerializeObject(value);
        }

        private static string SerializeObject(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var parts = new List<string>();

            foreach (PropertyInfo prop in props)
            {
                // Skip indexers (e.g. this[int])
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                // Detect Nullable<T>  e.g.  int?  DateTime?
                bool isNullable = IsNullableType(prop.PropertyType);

                object rawValue = prop.GetValue(obj);

                string serialized = SerializeValue(rawValue, isNullableContext: isNullable);

                // Nullable<T> property whose value was never set → omit property key entirely
                if (serialized == SkipSentinel)
                    continue;

                parts.Add("\"" + prop.Name + "\":" + serialized);
            }

            return "{" + string.Join(",", parts) + "}";
        }

        private static string SerializeEnumerable(IEnumerable enumerable)
        {
            var items = new List<string>();

            foreach (object item in enumerable)
            {
                // Collection elements are not in a Nullable<T> property context
                items.Add(SerializeValue(item, isNullableContext: false));
            }

            return "[" + string.Join(",", items) + "]";
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static bool IsNullableType(Type t)
        {
            // Nullable<T>  is a closed generic value type: Nullable<int>, Nullable<DateTime> …
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        private static bool IsNumericType(Type t)
        {
            switch (Type.GetTypeCode(t))
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
                    return true;
                default:
                    return false;
            }
        }

        private static string EscapeString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new System.Text.StringBuilder(input.Length);
            foreach (char c in input)
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
            return sb.ToString();
        }
    }
}