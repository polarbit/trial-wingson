using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using WingsOn.Domain.BaseObjects;
using Xunit;

namespace WingsOn.Dal.UnitTests
{
    public class RepositoryBaseTests
    {
        [Fact]
        public void Test_GetById_ForExistingEntity()
        {
            // Arrange
            var repository = new SampleEntityRepository();
            var newEntity = new SampleEntity(1, Guid.NewGuid().ToString());
            repository.ExportedListForTest.Add(newEntity);

            // Act
            var savedEntity = repository.Get(newEntity.Id);

            // Assert
            Assert.NotNull(savedEntity);
            Assert.Equal(savedEntity.Id, newEntity.Id);
            Assert.Equal(savedEntity.Name, newEntity.Name);
        }

        [Fact]
        public void Test_GetById_ForNotExistingEntity()
        {
            // Arrange
            var repository = new SampleEntityRepository();

            // Act
            var notExistingEntity = repository.Get(1);

            // Assert
            Assert.Null(notExistingEntity);
        }

        [Fact]
        public void Test_Save_NewEntity()
        {
            // Arrange
            var repository = new SampleEntityRepository();
            var newEntity = new SampleEntity(1, Guid.NewGuid().ToString());

            // Act
            repository.Save(newEntity);

            // Assert
            var savedEntity = repository.ExportedListForTest.SingleOrDefault(x => x.Id == newEntity.Id);
            Assert.NotNull(savedEntity);
            Assert.Equal(savedEntity.Name, newEntity.Name);
        }

        [Fact]
        public void Test_Save_Null()
        {
            // Arrange
            var repository = new SampleEntityRepository();

            // Act
            repository.Save(null);

            // Assert
            Assert.Empty(repository.ExportedListForTest);
        }

        [Fact]
        public void Test_Save_ExistingEntity()
        {
            // Arrange
            var repository = new SampleEntityRepository();
            var currentEntity = new SampleEntity(1, Guid.NewGuid().ToString());
            repository.ExportedListForTest.Add(currentEntity);
            var updatingEntity = new SampleEntity(currentEntity.Id, Guid.NewGuid().ToString());

            // Act
            repository.Save(updatingEntity);

            // Assert
            Assert.Single(repository.ExportedListForTest);
            var savedEntity = repository.ExportedListForTest.SingleOrDefault(x => x.Id == updatingEntity.Id);
            Assert.NotNull(savedEntity);
            Assert.Equal(savedEntity.Name, updatingEntity.Name);
        }

        [Fact]
        public void Test_GetAll()
        {
            // Arrange
            var repository = new SampleEntityRepository();
            var newEntity1 = new SampleEntity(1, Guid.NewGuid().ToString());
            var newEntity2 = new SampleEntity(2, Guid.NewGuid().ToString());
            repository.ExportedListForTest.Add(newEntity1);
            repository.ExportedListForTest.Add(newEntity2);

            //  Act
            var savedEntities = repository.GetAll();

            // Arrange
            Assert.NotNull(savedEntities);
            savedEntities.Count().Equals(2);
            Assert.Contains(savedEntities, x => x.Id == newEntity1.Id && x.Name == newEntity1.Name);
            Assert.Contains(savedEntities, x => x.Id == newEntity2.Id && x.Name == newEntity2.Name);
        }

        [Fact]
        public void Test_GetAll_ForEmptyRepository()
        {
            // Arrange
            var repository = new SampleEntityRepository();

            //  Act
            var emptyList = repository.GetAll();

            // Arrange
            Assert.NotNull(emptyList);
            Assert.Empty(emptyList);
        }

        public class SampleEntity : DomainEntity
        {
            public SampleEntity(int id, string name) : base(id)
            {
                Name = name;
            }

            public string Name { get; }
        }

        public class SampleEntityRepository : RepositoryBase<SampleEntity>
        {
            public List<SampleEntity> ExportedListForTest => Repository;
        }
    }
}
