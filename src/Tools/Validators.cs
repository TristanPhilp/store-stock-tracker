namespace store_stock_tracker.src.Tools
{
    using store_stock_tracker.src.Interfaces;
    using System.Text.RegularExpressions;


    //Validators are based on strategy pattern to reduce bloat
    public class SelectValidator : IValidationStrategy
    {
        /// <summary>
        /// Validates that a query is a properly formatted SELECT statement
        /// targeting only the specified table.
        /// </summary>
        public bool Validate(string query, string allowedTable)
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

    public class UpdateValidator : IValidationStrategy
    {
        /// <summary>
        /// Validates that a query is a properly formatted UPDATE statement
        /// targeting only the specified table.
        /// </summary>
        public bool Validate(string query, string allowedTable)
        {
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(allowedTable))
                return false;

            // Normalize whitespace
            string normalized = query.Trim();

            // Reject multiple statements (basic injection prevention)
            if (normalized.Contains(";") && !normalized.EndsWith(";"))
                return false;

            // Remove trailing semicolon if present
            normalized = normalized.TrimEnd(';').Trim();

            // Regex pattern:
            // - Must start with UPDATE <allowedTable>
            // - Must contain SET clause
            // - Optional WHERE clause
            string pattern = $@"^UPDATE\s+{Regex.Escape(allowedTable)}\s+SET\s+.+(\s+WHERE\s+.+)?$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!regex.IsMatch(normalized))
                return false;

            // Disallow other SQL operations
            string[] forbidden = { "SELECT", "INSERT", "DELETE", "DROP", "ALTER", "TRUNCATE", "ATTACH", "DETACH" };

            foreach (var keyword in forbidden)
            {
                if (Regex.IsMatch(normalized, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                    return false;
            }

            return true;
        }
    }
    public class DeleteValidator : IValidationStrategy
    {
        public bool Validate(string query, string allowedTable)
        {
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(allowedTable))
                return false;

            string normalized = query.Trim();

            // Reject multiple statements
            if (normalized.Contains(";") && !normalized.EndsWith(";"))
                return false;

            normalized = normalized.TrimEnd(';').Trim();

            // Require DELETE FROM <table> with optional WHERE
            string pattern = $@"^DELETE\s+FROM\s+{Regex.Escape(allowedTable)}(\s+WHERE\s+.+)?$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!regex.IsMatch(normalized))
                return false;

            // Disallow other SQL operations
            string[] forbidden = { "SELECT", "INSERT", "UPDATE", "DROP", "ALTER", "TRUNCATE", "ATTACH", "DETACH" };

            foreach (var keyword in forbidden)
            {
                if (Regex.IsMatch(normalized, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                    return false;
            }

            return true;
        }
    }
    public class InsertValidator : IValidationStrategy
    {
        /// <summary>
        /// Validates that a query is a properly formatted INSERT INTO statement
        /// targeting only the specified table.
        /// </summary>
        public bool Validate(string query, string allowedTable)
        {
            if (string.IsNullOrWhiteSpace(query) || string.IsNullOrWhiteSpace(allowedTable))
                return false;

            string normalized = query.Trim();

            // Reject multiple statements
            if (normalized.Contains(";") && !normalized.EndsWith(";"))
                return false;

            normalized = normalized.TrimEnd(';').Trim();

            // Require INSERT INTO <table> (...) VALUES (...)
            // Column list is optional in SQLite, but recommended—this allows both forms
            string pattern = $@"^INSERT\s+INTO\s+{Regex.Escape(allowedTable)}\s*(\(.+\))?\s+VALUES\s*\(.+\)$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (!regex.IsMatch(normalized))
                return false;

            // Disallow other SQL operations
            string[] forbidden = { "SELECT", "UPDATE", "DELETE", "DROP", "ALTER", "TRUNCATE", "ATTACH", "DETACH" };

            foreach (var keyword in forbidden)
            {
                if (Regex.IsMatch(normalized, $@"\b{keyword}\b", RegexOptions.IgnoreCase))
                    return false;
            }

            return true;
        }
    }
}
