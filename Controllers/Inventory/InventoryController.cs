using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryTravelApi.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController: ControllerBase
    {
        private readonly IConfiguration _configurarion;

        public InventoryController(IConfiguration configuration)
        {
            _configurarion = configuration;
        }

        [HttpGet("{p_0}")]
        public ActionResult<Models.Inventory.InventoryModel> InventoryByBook(string p_0)
        {
            try
            {
                Encrypted.Encrypted encrypted = new Encrypted.Encrypted();

                var p_d_0 = encrypted.Base64Decode(p_0);
                    
                SqlConnection connection = new SqlConnection(_configurarion.GetConnectionString("Server"));
                SqlCommand cmd = new SqlCommand("SP_SEL_INVENTORY_BY_BOOK", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("p_0", p_d_0.ToString()));


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();

                Models.Inventory.InventoryModel inventory = new Models.Inventory.InventoryModel();

                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
                {
                    var encode_0 = encrypted.Base64Encode(Convert.ToString(dt.Rows[0].ItemArray[2]));
                    var encode_1 = encrypted.Base64Encode(Convert.ToString(dt.Rows[0].ItemArray[3]));
                    var encode_2 = encrypted.Base64Encode(Convert.ToString(dt.Rows[0].ItemArray[4]));

                    inventory.IdAuthor = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                    inventory.ISBNBook = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                    inventory.Book = encode_0;
                    inventory.Editorial = encode_1;
                    inventory.Author = encode_2;


                    return inventory;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("{p_0}")]
        public ActionResult<Models.Inventory.InventoryModel> InventoryDetailBySBN(string p_0)
        {
            try
            {
                Encrypted.Encrypted encrypted = new Encrypted.Encrypted();

                var p_d_0 = encrypted.Base64Decode(p_0);

                SqlConnection connection = new SqlConnection(_configurarion.GetConnectionString("Server"));
                SqlCommand cmd = new SqlCommand("SP_SEL_BOOK_DETAIL_BY_ISBN", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("p_0", Convert.ToInt32(p_d_0)));


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();

                Models.Inventory.InventoryModel inventory = new Models.Inventory.InventoryModel();

                if (Convert.ToInt32(dt.Rows[0].ItemArray[0]) > 0)
                {
                    var encode_0 = encrypted.Base64Encode(Convert.ToString(dt.Rows[0].ItemArray[2]));
                    var encode_1 = encrypted.Base64Encode(Convert.ToString(dt.Rows[0].ItemArray[3]));

                    inventory.IdAuthor = Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                    inventory.ISBNBook = Convert.ToInt32(dt.Rows[0].ItemArray[1]);
                    inventory.Book = encode_0;
                    inventory.Editorial = encode_1;

                    return inventory;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
