using AutoMapper;
using GoogleBooks.Application.Common.Mappings;
using GoogleBooks.Domain.Entities;

namespace GoogleBooks.Application.NonConformities.Queries.GetNonConformity
{
    public class ActionDto : IMapFrom<Action>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Action, ActionDto>()
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => (int)s.Id));
        }
    }
}