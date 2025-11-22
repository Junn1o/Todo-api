using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        GetUSerCategory getUSerCategories(int userId);
        UserCategoryWithTask userCategoryWithTask(int userId, int categoryId, int pageSize, int pageNumber);
        CategoryRequestFromDTO categoryRequestFromDTO(CategoryRequestFromDTO addCategoryDTO);
        CategoryRequestFromDTO categoryUpdateFromDTO(int userId, int categoryId, CategoryRequestFromDTO updateCategoryDTO);
        Category deleteCategory(int categoryId, int userId);
    }
}
