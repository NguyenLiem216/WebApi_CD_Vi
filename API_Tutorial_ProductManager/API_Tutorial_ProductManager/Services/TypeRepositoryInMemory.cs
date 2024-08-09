using API_Tutorial_ProductManager.Models;
using System;

namespace API_Tutorial_ProductManager.Services
{
    public class TypeRepositoryInMemory : ITypeRepository
    {
        static List<TypeVM> typeVMs = new List<TypeVM>()
        {
            new TypeVM{Id_Type = 1 , TypeName = "Thuốc" },
            new TypeVM{Id_Type = 2 , TypeName = "Thực phẩm bổ sung" },
            new TypeVM{Id_Type = 3 , TypeName = "Kẹo" },
            new TypeVM{Id_Type = 4 , TypeName = "Bánh" },

        };
        public TypeVM Add(ModelType type)
        {
            var _type = new TypeVM
            {
                Id_Type = typeVMs.Max(tm => tm.Id_Type) + 1,
                TypeName = type.TypeName,
            };
            typeVMs.Add(_type);
            return _type;
        }

        public void Delete(int id)
        {
            var _types = typeVMs.SingleOrDefault(tm => tm.Id_Type == id);
            if( _types != null)
            {
                typeVMs.Remove(_types);
            }
        }

        public List<TypeVM> GetAll()
        {
            return typeVMs;
        }

        public TypeVM? GetById(int id)
        {
            return typeVMs.SingleOrDefault(tm => tm.Id_Type == id );
        }

        public void Update(TypeVM typeVM)
        {
            var _types = typeVMs.SingleOrDefault(tm => tm.Id_Type == typeVM.Id_Type);
            if (_types != null)
            {
                _types.TypeName = typeVM.TypeName;
            }
        }
    }
}
