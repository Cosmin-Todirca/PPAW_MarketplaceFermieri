using AutoMapper;
using DTOs;
using Repository_DBFirst;

namespace BusinessLayer_DBFirst
{
    public class MapperConfig
    {
        public static MapperConfiguration InitializeAutomapper()
        {
            // Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                // Configuring Source and Destination
                cfg.CreateMap<vanzatori, ReadVanzatorCardViewModel>();
                // Any Other Mapping Configuration ....
            });
            return config;
        }
    }
}
