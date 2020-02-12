using System;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Shared.Values
{
    public class FullNameTests
    {
        [Fact]
        public void Test_WithTooLongName_ShouldThrow()
        {
            // Arrange
            var tooLangName = "".PadLeft(25, 'A') + " " + "".PadLeft(25, 'B');

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FullName(tooLangName));
            Assert.Contains("50 characters", ex.Message);
        }

        [Fact]
        public void Test_WithSinglePartName()
        {
            // Arrange
            var singlePartName = "".PadLeft(15, 'A') + " ";

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FullName(singlePartName)); 
            Assert.Contains("at least two name parts", ex.Message);
        }
        
        [Fact]
        public void Test_WithNonLetters_ShouldThrow()
        {
            // Arrage
            var invalidName = "1nval1d N5me";

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FullName(invalidName));
            Assert.Contains("should only contain letters and whitespaces", ex.Message);
        }

        [Fact]
        public void Test_WithNullParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new FullName(null));
        }

        [Fact]
        public void Test_WithEmptyParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new FullName(""));
        }

        [Fact]
        public void Test_FullnameToStringCasting()
        {
            // Arrange
            FullName fullname = new FullName("Name Surname");

            // Act
            string fullnameString = fullname;

            // Arrange
            Assert.Equal(fullname, fullnameString);
            Assert.Equal(fullname.GetHashCode(), fullnameString.GetHashCode());
            Assert.Equal(fullname.ToString(), fullnameString);
            Assert.True(fullname.Equals(fullnameString));
        }

        [Fact]
        public void Test_StringToFullnameCasting()
        {
            // Arrrange
            string fullnameString = "Name Surname";

            // Act
            FullName fullname = fullnameString;

            // Assert
            Assert.Equal(fullnameString, fullname);
            Assert.Equal(fullnameString.GetHashCode(), fullname.GetHashCode());
            Assert.Equal(fullnameString, fullname.ToString());
            Assert.True(fullname.Equals(fullnameString));
        }

        [Fact]
        public void Test_NullStringToFullnameCasting_ShouldBeNull()
        {
            // Act
            FullName fullname = (string) null;

            // Assert
            Assert.Null(fullname);
        }

        [Fact]
        public void Test_NullFullnameToStringCasting_ShouldBeNull()
        {
            // Act
            string fullnameString = (FullName) null;

            // Assert
            Assert.Null(fullnameString);
        }

        [Fact]
        public void Test_ToSeperateFullnames_WithSameValue_EqualsToTrue()
        {
            // Arrange
            FullName name1 = "First Name";
            FullName name2 = "First Name";

            // Assert
            Assert.True(name1.Equals(name2));
            Assert.Equal(name1, name2);
        }
    }
}
