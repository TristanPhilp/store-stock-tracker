namespace store_stock_tracker.src.Cli.Utils
{
    using System.Text.RegularExpressions;

    public static class Validators
    {
        /// <summary>
        /// Validates that a query is a properly formatted SELECT statement
        /// targeting only the specified table.
        /// </summary>
        public static bool IsValidSelectQuery(string query, string allowedTable)
        {
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(allowedTable))
                return false;

            // Normalize whitespace and casing
            string normalized = query.Trim();

            // Reject multiple statements (basic injection prevention)
            if (normalized.Contains(";") && !normalized.EndsWith(";"))
                return false;

            // Remove trailing semicolon if present
            normalized = normalized.TrimEnd(';').Trim();

            // Regex pattern:
            // - Must start with SELECT
            // - Must contain FROM <allowedTable>
            // - Disallow INSERT, UPDATE, DELETE, DROP, etc.
            string pattern = $@"^SELECT\s+.+\s+FROM\s+{Regex.Escape(allowedTable)}(\s+WHERE\s+.+)?(\s+ORDER\s+BY\s+.+)?$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!regex.IsMatch(normalized))
                return false;

            // Disallow dangerous keywords explicitly
            string[] forbidden = { "INSERT", "UPDATE", "DELETE", "DROP", "ALTER", "TRUNCATE", "ATTACH", "DETACH" };

            foreach (var keyword in forbidden)
            {
                if (Regex.IsMatch(normalized, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                    return false;
            }

            return true;
        }
    }
}
