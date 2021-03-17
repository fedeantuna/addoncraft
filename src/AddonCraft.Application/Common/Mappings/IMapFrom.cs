using AutoMapper;

namespace AddonCraft.Application.Common.Mappings
{
    /// <summary>
    /// Defines the mapping contract.
    /// </summary>
    /// <typeparam name="T">The class from which the mapping will be done.</typeparam>
    public interface IMapFrom<T>
        where T : class
    {
        /// <summary>
        /// Sets the mapping configuration.
        /// </summary>
        /// <param name="profile">The profile for the map.</param>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), this.GetType());
    }
}