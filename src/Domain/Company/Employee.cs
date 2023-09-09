using Luna.Core.Domain.Common.Contracts;

namespace Luna.Core.Domain.Company
{
    public class Employee : AuditEntity
    {
        public Guid EmployeeId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid ApplicationUserId { get; private set; }
        public Employee(Guid employeeId, string firstName, string lastName, Guid applicationUserId)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            ApplicationUserId = applicationUserId;
        }
    }
}