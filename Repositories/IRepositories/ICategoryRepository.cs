using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        List<GetUSerCategory> getUSerCategories();
        List<UserCategoryWithTask> userCategoryWithTask(Guid userId, Guid categoryId, int pageSize, int pageNumber);
        CategoryRequestFromDTO categoryRequestFromDTO(CategoryRequestFromDTO addCategoryDTO);
        CategoryRequestFromDTO categoryUpdateFromDTO(CategoryRequestFromDTO updateCategoryDTO);
        Category deleteCategory(Guid categoryId);
    }
}
