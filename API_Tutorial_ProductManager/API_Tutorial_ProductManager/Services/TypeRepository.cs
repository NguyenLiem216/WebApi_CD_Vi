using API_Tutorial_ProductManager.Data;
using API_Tutorial_ProductManager.Models;

namespace API_Tutorial_ProductManager.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DContext _context;

        public TypeRepository(DContext context) 
        {
            _context = context;
        }
        public TypeVM Add(ModelType type)
        {
            var _types = new Products_Type
            {
                TypeName = type.TypeName
            };
            _context.Add(_types);
            _context.SaveChanges();

            return new TypeVM
            {
                Id_Type = _types.Id_Type,
                TypeName = _types.TypeName
            };
        }

        public void Delete(int id)
        {
            var type = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == id);
            if (type != null)
            {
                _context.Remove(type);
                _context.SaveChanges();
            }

        }

        public List<TypeVM> GetAll()
        {
            var types = _context.Product_Types.Select(pt => new TypeVM { 
                Id_Type = pt.Id_Type,
                TypeName = pt.TypeName
            });
            return types.ToList();
        }

        public TypeVM? GetById(int id)
        {
            var type = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == id);
            if (type != null)
            {
                return new TypeVM
                {
                    Id_Type = type.Id_Type,
                    TypeName = type.TypeName
                };
            }
            return null;
        }

        public void Update(TypeVM typeVM)
        {
            var _type = _context.Product_Types.SingleOrDefault(pt => pt.Id_Type == typeVM.Id_Type);
            typeVM.TypeName = typeVM.TypeName;
            _context.SaveChanges();
        }
    }
}
