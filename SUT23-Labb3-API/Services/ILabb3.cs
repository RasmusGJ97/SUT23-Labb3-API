namespace SUT23_Labb3_API.Services
{
    public interface ILabb3<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<List<T>> GetSpecific(int id);
        Task<T> Add(T newEntity);
    }
}
