using AutoMapper;

namespace signalR.Core
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => 
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}