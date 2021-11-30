using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }

        // GET
        public IHttpActionResult Get()
        {
            var catService = CreateCategoryService();
            var categories = catService.GetCategories();
            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            CategoryService catService = CreateCategoryService();
            var category = catService.GetCategoryById(id);
            return Ok(category);
        }

        //POST
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        //PUT (update)
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var catService = CreateCategoryService();

            if (!catService.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        //DELTE
        public IHttpActionResult Delete(int id)
        {
            var catService = CreateCategoryService();

            if (!catService.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }

    }
}
