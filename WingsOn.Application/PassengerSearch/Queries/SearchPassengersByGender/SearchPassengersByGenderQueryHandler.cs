﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.PassengerSearch.Repositories;
using WingsOn.Application.PassengerSearch.Resources;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Application.PassengerSearch.Queries.SearchPassengersByGender
{
    public class SearchPassengersByGenderQueryHandler : IQueryHandler<SearchPassengersByGenderQuery, IEnumerable<PassengerResource>>
    {
        private readonly IPassengerSearchRepository _repository;

        public SearchPassengersByGenderQueryHandler(IPassengerSearchRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PassengerResource>> Handle(SearchPassengersByGenderQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .GetPassengersByGender(request.Gender)
                .Select(p => new PassengerResource
                {
                    Id = p.Id,
                    Email = p.Email,
                    Name = p.Name,
                    DateBirth = p.DateBirth,
                    Gender = (Gender) p.Gender,
                    Address = p.Address
                });

            return Task.FromResult(result);
        }
    }
}