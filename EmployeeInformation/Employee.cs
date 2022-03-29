namespace EmployeeInformation
{
    internal class Employee
    {
        public bool IsNew { get; set; } = true;
        public int EmployeeID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public decimal? PayPerHour { get; set; } = decimal.Zero;
    }
}
