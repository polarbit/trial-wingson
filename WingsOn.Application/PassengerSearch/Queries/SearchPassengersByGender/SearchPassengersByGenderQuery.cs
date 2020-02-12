using System.Collections.Generic;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.PassengerSearch.Resources;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Application.PassengerSearch.Queries.SearchPassengersByGender
{
    public class SearchPassengersByGenderQuery : IQuery<IEnumerable<PassengerResource>>
    {
        public SearchPassengersByGenderQuery(Gender gender)
        {
            Gender = gender;
        }

        public Gender Gender { get;  }
    }
}
