using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSSLNCSApi.Controllers
{
    public class RevenueViewModel
    {
        public string MainCatCode { get; set; }
        public string MainCatDesc { get; set; }
        public List<RevenueSubCategory> SubCategories { get; set; }
    }

    public class RevenueSubCategory
    {
        public string RevCode { get; set; }
        public string SubCatCode { get; set; }
        public string SubCatDesc { get; set; }
        public decimal? Rate { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {

        private readonly BSSLSYS_ITFContext context;

        public RevenueController(BSSLSYS_ITFContext _context)
        {
            context = _context;
        }

        [HttpGet("GetRevenueCategories")]
        public IActionResult GetCat()
        {
            try
            {
                var data = new Dictionary<string, RevenueViewModel>();

                var subCats = context.Revenue.ToList();

                foreach (var subCat in subCats)
                {
                    if (!data.ContainsKey(subCat.Category))
                    {
                        data.Add(subCat.Category, new RevenueViewModel
                        {
                            MainCatCode = subCat.Category,
                            MainCatDesc = context.Revenuecat.FirstOrDefault(x => x.Catcode == subCat.Category).Catrevdesc,
                            SubCategories = new List<RevenueSubCategory> {
                                new RevenueSubCategory { 
                                     RevCode = $"{subCat.Subcode}{subCat.Revcode}",
                                    Rate = subCat.Revenuerate, 
                                    SubCatCode = subCat.Subcode, 
                                    SubCatDesc = subCat.Revdesc } 
                            }
                        });
                    }
                    else
                    {
                       data[subCat.Category].SubCategories.Add(
                         new RevenueSubCategory {
                             RevCode = $"{subCat.Subcode}{subCat.Revcode}",
                             Rate = subCat.Revenuerate,
                                    SubCatCode = subCat.Subcode,
                                    SubCatDesc = subCat.Revdesc 
                         }
                       );
                    }
                }

                return Ok(data.Values.ToList());
            }
            catch (NullReferenceException e)
            {
                return StatusCode(500, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }        


        }

    }
}