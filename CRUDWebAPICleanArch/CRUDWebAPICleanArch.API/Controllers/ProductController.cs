using CRUDWebAPICleanArch.API.Models;
using CRUDWebAPICleanArch.Application.Interfaces;
using CRUDWebAPICleanArch.Core.Entities;
using CRUDWebAPICleanArch.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUDWebAPICleanArch.API.Controllers
{
    //[Route("api/[controller]/[Action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Initialize ProductController by injecting an object type of IUnitOfWork
        /// </summary>
        public ProductController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpGet]
        public async Task<ApiResponse<List<Product>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Product>>();

            try
            {
                var data = await _unitOfWork.ProductRepo.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpGet("GetByID/{id}")]
        //[HttpGet]
        public async Task<ApiResponse<Product>> GetById(int id)
        {

            var apiResponse = new ApiResponse<Product>();

            try
            {
                var data = await _unitOfWork.ProductRepo.GetByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse<string>> Add(Product product)
        {
            var apiResponse = new ApiResponse<string>();
            if (product.PrdDescription =="")
            {
                apiResponse.Success = false;
                apiResponse.Message = "Product Description should not be empty.";

            }
            else if (product.ProductPrice <0)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Product Price should not be less than Zero.";
            }
            else
            {
                try
                {
                    var data = await _unitOfWork.ProductRepo.AddAsync(product);
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                catch (SqlException ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("SQL Exception:", ex);
                }
                catch (Exception ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("Exception:", ex);
                }
            }

          
            return apiResponse;
        }

        [HttpPut]
        public async Task<ApiResponse<string>> Update(Product product)
        {
            var apiResponse = new ApiResponse<string>();

            if (product.ProductId <= 0)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Product Id not match. Invaild product id.";
            }
            else if(product.PrdDescription=="")
            {
                apiResponse.Success = false;
                apiResponse.Message = "Product Description should not be empty.";
            }
            else
            {
                try
                {
                    var data = await _unitOfWork.ProductRepo.UpdateAsync(product);
                    if (data !="0")
                    {
                        apiResponse.Success = true;
                        apiResponse.Message = "Product Update Successfull.";
                        apiResponse.Result = data;

                    }
                    else if (data =="0")
                    {
                        apiResponse.Success = false;
                        apiResponse.Message = "Product Update Failed!!";
                        apiResponse.Result = data;
                    }
                    
                }
                catch (SqlException ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("SQL Exception:", ex);
                }
                catch (Exception ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("Exception:", ex);
                }
            }
           

            return apiResponse;
        }

        [HttpDelete]
        public async Task<ApiResponse<string>> Delete(int id)
        {
            var apiResponse = new ApiResponse<string>();
            
            if (id <= 0)
            {
                apiResponse.Success = false;
                apiResponse.Message = "Product Id not match. Invaild product id.";
            }
            else
            {
                try
                {
                    var data = await _unitOfWork.ProductRepo.DeleteAsync(id);

                    if (data != "0")
                    {
                        apiResponse.Success = true;
                        apiResponse.Message = "Product Delete Successfull.";
                        apiResponse.Result = data;

                    }
                    else if (data == "0")
                    {
                        apiResponse.Success = false;
                        apiResponse.Message = "Product Delete Failed!!";
                        apiResponse.Result = data;
                    }
                }
                catch (SqlException ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("SQL Exception:", ex);
                }
                catch (Exception ex)
                {
                    apiResponse.Success = false;
                    apiResponse.Message = ex.Message;
                    Logger.Instance.Error("Exception:", ex);
                }
            }
          

            return apiResponse;
        }

        #endregion

    }
}
