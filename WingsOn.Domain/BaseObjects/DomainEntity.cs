namespace WingsOn.Domain.BaseObjects
{
    public class DomainEntity
    {
        protected DomainEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
