namespace OneC
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid OrganizationId {  get; set; }
        public required string Organization { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
