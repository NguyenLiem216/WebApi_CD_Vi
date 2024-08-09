using API_Tutorial_ProductManager.Models;

namespace API_Tutorial_ProductManager.Services
{
    public interface ITypeRepository
    {
        List<TypeVM> GetAll();
        TypeVM? GetById(int id);
        TypeVM Add(ModelType type);
        
        void Update(TypeVM typeVM);
        void Delete(int id);
    }
}
