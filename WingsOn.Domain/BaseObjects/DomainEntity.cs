namespace WingsOn.Domain.BaseObjects
{
    public abstract class DomainEntity
    {
        protected DomainEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
