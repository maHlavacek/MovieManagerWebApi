using Microsoft.AspNetCore.Mvc;
using MovieManager.Core.Contracts;
using MovieManager.Core.DataTransferObjects;
using System.Linq;

namespace MovieManager.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : IUnitOfWork
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IMovieRepository MovieRepository => throw new System.NotImplementedException();

        public ICategoryRepository CategoryRepository => throw new System.NotImplementedException();

        public void DeleteDatabase()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public string[] GetCategories()
        {

            return _unitOfWork
                .CategoryRepository
                .GetAll()
                .Select(category => category.CategoryName)
                .ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public CategoryWithMoviesDTO GetCategoryById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetByIdWithMovies(id);
            return new CategoryWithMoviesDTO(category);
        }

        [HttpGet]
        [Route("{id}/movies")]
        public MovieDTO[] GetMoviesByCategoryId(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetByIdWithMovies(id);
            return new CategoryWithMoviesDTO(category).Movies;
        }

        public void MigrateDatabase()
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}