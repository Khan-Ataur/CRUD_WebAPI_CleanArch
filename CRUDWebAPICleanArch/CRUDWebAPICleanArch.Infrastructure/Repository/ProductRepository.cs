using CRUDWebAPICleanArch.Infrastructure.Dapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDWebAPICleanArch.Core.Entities;

namespace CRUDWebAPICleanArch.Infrastructure.Repository
{
    internal class ProductRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;        
        DapperContext _dapperContext;

        #endregion

        #region ===[ Constructor ]=================================================================

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void DapperConnection()
        {
            _dapperContext = new DapperContext(_configuration);
        }

        #endregion

        #region ===[ IProductRepository Methods ]==================================================

        //public async Task<IReadOnlyList<Product>> GetAllAsync()
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.QueryAsync<Product>(ProductQueries.AllProduct);
        //        return result.ToList();
        //    }
        //}

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            DapperConnection();
            List<Product> productList = new List<Product>();
            var data = await _dapperContext.GetAllAsyncNew<Product>("sp_getProductList", commandType: CommandType.StoredProcedure);
            return data.ToList();
        }

        //public async Task<Product> GetByIdAsync(long id)
        //{
        //    DapperConnection();
        //    DynamicParameters parameters = new DynamicParameters();
        //    parameters.Add("ProductId", id);
        //    List<Product> productList = new List<Product>();
        //    var data = await _dapperContext.GetBySingleParamAsync<Product>("sp_getProductByProdId", parameters, commandType: CommandType.StoredProcedure);
        //    return data;
        //}

        //public async Task<string> AddAsync(Product entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(ProductQueries.AddProduct, entity);
        //        return result.ToString();
        //    }
        //}

        //public async Task<string> UpdateAsync(Product entity)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(ProductQueries.UpdateProduct, entity);
        //        return result.ToString();
        //    }
        //}

        //public async Task<string> DeleteAsync(long id)
        //{
        //    using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
        //    {
        //        connection.Open();
        //        var result = await connection.ExecuteAsync(ProductQueries.DeleteProduct, new { ProductId = id });
        //        return result.ToString();
        //    }
        //}

        #endregion

    }
}
